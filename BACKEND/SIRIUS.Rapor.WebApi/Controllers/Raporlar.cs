using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIRIUS.Rapor.Data.Models;
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

        [HttpGet]
        public IActionResult IslemAdedi()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.islemAdedi();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult OnayDurumuTutari()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.OnayDurumuTutari();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult ToplamBordroTutari()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.ToplamBordroTutari();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult SonIslemler()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.SonIslemler();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet]
        public IActionResult PazarlamaciBilgileri()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.PazarlamaciBilgileri();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult YeniMusteri()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.YeniMusteri();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        [HttpGet]
        public IActionResult Ziyaret()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.Ziyaret();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult HedefData()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.HedefData();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult CekAdetleri()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.CekAdetleri();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult MusteriRiskListesi()
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.MusteriRiskListesi();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult MusteriRiskListesiMap(string user)
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.MusteriRiskListesiMap(user);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult HedefDataGuncelleme(eko_HedefDataUpdateModel model)
        {
            RaporlarRepository pazarlamaPerformansRepository = new RaporlarRepository();
            var result = pazarlamaPerformansRepository.HedefDataGuncelleme(model);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
    
}