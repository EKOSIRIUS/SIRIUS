using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIRIUS.Rapor.Business.Abstract;
using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RaporlarController : ControllerBase
    {
        private readonly IRaporlarService _raporlarService;
        public RaporlarController(IRaporlarService raporlarService)
        {
            _raporlarService = raporlarService;
        }
        [HttpGet]
        public async Task<IActionResult> PazarlamaPerformans(int yil)
        {
            var result = await _raporlarService.GetPerformansRaporu(yil);

            if (result == null)
            {
                return NotFound("Rapor bulunumadı");
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> PlasmanDetay(int yil, int secim)
        {
            var result = await _raporlarService.GetPlasmanDetay(yil, secim);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> IslemAdedi()
        {
            var result = await _raporlarService.GetIslemAdedi();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> OnayDurumuTutari()
        {
            var result = await _raporlarService.GetOnayDurumTutari();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ToplamBordroTutari()
        {
            var result = await _raporlarService.GetBordroTutari();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> SonIslemler()
        {
            var result = await _raporlarService.GetSonIslemler();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> PazarlamaciBilgileri()
        {
            var result = await _raporlarService.GetPazarlamaciBilgileri();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> YeniMusteri()
        {
            var result = await _raporlarService.GetYeniMusteri();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Ziyaret()
        {
            var result = await _raporlarService.GetZiyaret();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> HedefData()
        {
            var result = await _raporlarService.GetHedefData();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> CekAdetleri()
        {
            var result = await _raporlarService.GetCekAdetleri();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> MusteriRiskListesi()
        {
            var result = await _raporlarService.GetMusteriRiskListesi();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> MusteriRiskListesiMap(string user)
        {
            var result = await _raporlarService.GetMusteriRiskListesiMap(user);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> HedefDataGuncelleme(eko_HedefDataUpdateModel model)
        {
            var result = await _raporlarService.UpdateHedefData(model);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}