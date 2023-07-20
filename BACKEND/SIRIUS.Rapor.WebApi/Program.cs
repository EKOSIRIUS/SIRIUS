using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Data.Entityframework.Contexts;
using SIRIUS.Rapor.Data.Models;

namespace SIRIUS.Rapor.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo { Title = "EKO Api Dökümantasyon", Version = "v1" });
            });

            builder.Services.AddCors(service => {
                service.AddPolicy("AllowOrigin", options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );
            });

            builder.Services.AddDbContext<dbsiriusContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbsirius"));
            });

            builder.Services.AddDbContext<dbfactoringContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbfactoring"));
            });

            builder.Services.AddIdentity<EkoUser,EkoRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                
                //options.SignIn.RequireConfirmedEmail = true;
                
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = false;
                
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
            }).AddDefaultTokenProviders()
                .AddEntityFrameworkStores<dbsiriusContext>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.Domain = "https://sirius.ekofactoring.com";
                    options.Cookie.Name = "EKO_WEB_Cookie";
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.LoginPath = "index";
                    options.LogoutPath = "index";
                });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "EKO_API_Cookie";
                options.LoginPath = "/api/account/login";
                options.LogoutPath = "/api/account/logout";
                options.Cookie = cookieBuilder;
                options.ExpireTimeSpan = TimeSpan.FromDays(60);
                options.SlidingExpiration = true;
            });

            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
              
            //}

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().WithMethods("POST", "OPTIONS", "GET"));
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(name : "swagger",pattern: "{controller=swagger}/index.html");
            app.MapControllers();
            app.Run();
        }
    }
}