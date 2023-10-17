using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.Data.Abstract
{
    public interface IFactoringProceduresRepository
    {
        Task<List<eko_PazarlamaPerformansRaporu>> eko_PazarlamaPerformansRaporu(int yil, string kullanici = "csason");
        Task<List<sel_eko_plasmandetay>> sel_eko_plasmandetay(int yil, int secim);
        Task<List<eko_IslemAdedi>> islemAdedi();
        Task<List<eko_IslemOnayDurumTutari>> OnayDurumuTutari();
        Task<List<eko_ToplamBordroTutari>> ToplamBordroTutari();
        Task<List<eko_SonIslemler>> SonIslemler();
        Task<List<eko_PazarlamaciBilgileri>> PazarlamaciBilgileri();
        Task<List<eko_YeniMusteri>> YeniMusteri();
        Task<List<eko_Ziyaret>> Ziyaret();
        Task<List<eko_CekAdetleri>> CekAdetleri();
        Task<List<eko_MusteriRiskListesi>> MusteriRiskListesi();
        Task<IEnumerable<eko_MusteriRiskListesiMap>> MusteriRiskListesiMap(string user = "Hepsi");
    }
}