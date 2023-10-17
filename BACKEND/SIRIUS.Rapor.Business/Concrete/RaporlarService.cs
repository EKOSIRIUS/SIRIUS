using SIRIUS.Rapor.Business.Abstract;
using SIRIUS.Rapor.Data.Abstract;
using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.Business.Concrete
{
    public class RaporlarService : ServiceBase, IRaporlarService
    {
        public RaporlarService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<List<eko_ToplamBordroTutari>> GetBordroTutari()
        {
            return await _unitOfWork.FactoringProceduresRepository.ToplamBordroTutari();        
        }
        public async Task<List<eko_CekAdetleri>> GetCekAdetleri()
        {
            return await _unitOfWork.FactoringProceduresRepository.CekAdetleri();
        }
        public async Task<List<EkoHedefT>> GetHedefData()
        {
            return await _unitOfWork.SiriusProceduresRepository.HedefData();
        }
        public async Task<List<eko_IslemAdedi>> GetIslemAdedi()
        {
            return await _unitOfWork.FactoringProceduresRepository.islemAdedi();
        }
        public async Task<List<eko_MusteriRiskListesi>> GetMusteriRiskListesi()
        {
            return await _unitOfWork.FactoringProceduresRepository.MusteriRiskListesi();
        }
        public async Task<IEnumerable<eko_MusteriRiskListesiMap>> GetMusteriRiskListesiMap(string user)
        {
            return await _unitOfWork.FactoringProceduresRepository.MusteriRiskListesiMap(user);
        }
        public async Task<List<eko_IslemOnayDurumTutari>> GetOnayDurumTutari()
        {
            return await _unitOfWork.FactoringProceduresRepository.OnayDurumuTutari();
        }
        public async Task<List<eko_PazarlamaciBilgileri>> GetPazarlamaciBilgileri()
        {
            return await _unitOfWork.FactoringProceduresRepository.PazarlamaciBilgileri();
        }
        public async Task<List<eko_PazarlamaPerformansRaporu>> GetPerformansRaporu(int yil,string kullanici = "csason")
        {
            return await _unitOfWork.FactoringProceduresRepository.eko_PazarlamaPerformansRaporu(yil,kullanici);
        }
        public async Task<List<sel_eko_plasmandetay>> GetPlasmanDetay(int yil, int secim)
        {
            return await _unitOfWork.FactoringProceduresRepository.sel_eko_plasmandetay(yil,secim);
        }
        public async Task<List<eko_SonIslemler>> GetSonIslemler()
        {
            return await _unitOfWork.FactoringProceduresRepository.SonIslemler();
        }
        public async Task<List<eko_YeniMusteri>> GetYeniMusteri()
        {
            return await _unitOfWork.FactoringProceduresRepository.YeniMusteri();
        }
        public async Task<List<eko_Ziyaret>> GetZiyaret()
        {
            return await _unitOfWork.FactoringProceduresRepository.Ziyaret();
        }
        public async Task<bool> UpdateHedefData(eko_HedefDataUpdateModel model)
        {
            return await _unitOfWork.SiriusProceduresRepository.HedefDataGuncelleme(model);
        }
    }
}