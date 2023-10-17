using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.Business.Abstract
{
    public interface IRaporlarService
    {
        Task<List<eko_PazarlamaPerformansRaporu>> GetPerformansRaporu(int yil,string kullanici = "csason");
        Task<List<sel_eko_plasmandetay>> GetPlasmanDetay(int yil, int secim);
        Task<List<eko_IslemAdedi>> GetIslemAdedi();
        Task<List<eko_IslemOnayDurumTutari>> GetOnayDurumTutari();
        Task<List<eko_ToplamBordroTutari>> GetBordroTutari();
        Task<List<eko_SonIslemler>> GetSonIslemler();
        Task<List<eko_YeniMusteri>> GetYeniMusteri();
        Task<List<eko_PazarlamaciBilgileri>> GetPazarlamaciBilgileri();
        Task<List<eko_Ziyaret>> GetZiyaret();
        Task<List<EkoHedefT>> GetHedefData();
        Task<List<eko_CekAdetleri>> GetCekAdetleri();
        Task<List<eko_MusteriRiskListesi>> GetMusteriRiskListesi();
        Task<IEnumerable<eko_MusteriRiskListesiMap>> GetMusteriRiskListesiMap(string user);
        Task<bool> UpdateHedefData(eko_HedefDataUpdateModel model);
    }
}