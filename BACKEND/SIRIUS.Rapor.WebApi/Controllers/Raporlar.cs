using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIRIUS.Rapor.Data.Repositories;

namespace SIRIUS.Rapor.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class Raporlar : ControllerBase
    {
        [HttpGet]
    
        public IActionResult PazarlamaPerformans(int yil)
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.eko_PazarlamaPerformansRaporu(yil);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet]
        public IActionResult PlasmanDetay(int yil,int secim)
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.sel_eko_plasmandetay(yil, secim);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}