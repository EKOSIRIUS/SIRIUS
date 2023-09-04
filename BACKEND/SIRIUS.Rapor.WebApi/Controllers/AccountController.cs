using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SIRIUS.Rapor.Data.Models;
using SIRIUS.Rapor.WebApi.Models;
using SIRIUS.Rapor.WebApi.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;
using System.Security.Claims;

namespace SIRIUS.Rapor.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<EkoUser> _userManager;
        private readonly SignInManager<EkoUser> _signInManager;
        public AccountController(UserManager<EkoUser> userManager, SignInManager<EkoUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [SwaggerOperation(summary:"Giriş işlemi için kullanılmaktadır.")]
        public async Task<IActionResult> Login(SignInModel request)
        {
            var hasUser = await _userManager.FindByEmailAsync(request.Email);

            if (hasUser == null)
            {
                return Ok("Kullanıcı Bulunamadı");
            }

            var result = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);

            if (result.IsLockedOut)
            {
                return Ok("3 dakika boyunca giriş yapılamaz.");
            }

            if (result.Succeeded)
            {
                var roles =  await _userManager.GetRolesAsync(hasUser);
                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Email, hasUser.Email));
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperty = new AuthenticationProperties
                {
                    RedirectUri = @"/index.html"
                };
                foreach (var role in roles)
                {
                    new Claim(ClaimTypes.Role, role);
                }
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                                              , new ClaimsPrincipal(claimIdentity)
                                              , authenticationProperty);
                return Ok(hasUser);
            }

            string errorMessage = "Email veya şifre hatalı\t";

            if (hasUser != null)
            {
                int failedCount = await _userManager.GetAccessFailedCountAsync(hasUser);
                errorMessage += "Başarısız giriş sayısı: " + failedCount.ToString();
            }

            return BadRequest(errorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

            return Ok("Çıkış başarılı");
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel request)
        {
            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = request.UserName,
                Email = request.Email
            },request.Password);

            if (identityResult.Succeeded) return Ok();
            
            return Ok(identityResult.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel request)
        {
            var hasUser = await _userManager.FindByEmailAsync(request.Email);

            if (hasUser == null)
            {
                return Ok("Kullanıcı bulunamadı");
            }

            string passwordRefreshToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);

            var refreshLink = Url.Action("ResetPassword", "Account", new
            {
                UserId = hasUser.Id,
                Token = passwordRefreshToken
            },HttpContext.Request.Scheme);

            // TODO: Email Service yazılacak
            EmailService emailService = new EmailService();
            await emailService.SendForgotEmail(refreshLink, request.Email);

            return Ok();
        }
    }
}