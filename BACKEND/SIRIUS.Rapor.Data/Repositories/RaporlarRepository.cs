using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Data.Entityframework.Contexts;
using SIRIUS.Rapor.Data.Models;

namespace SIRIUS.Rapor.Data.Repositories
{
    public class RaporlarRepository
    {
        public List<eko_PazarlamaPerformansRaporu> eko_PazarlamaPerformansRaporu(int yil,string kullanici = "csason")
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_PazarlamaPerformansRaporu.FromSqlRaw($"eko_PazarlamaPerformansRaporu {yil} , '{kullanici}'").ToList();
                return data;
            }

        }

        public List<sel_eko_plasmandetay> sel_eko_plasmandetay(int yil,int secim)
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.sel_Eko_Plasmandetay.FromSqlRaw($"sel_eko_PlasmanDetay {yil} , {secim}").ToList();
                return data;
            }
        }

        public List<eko_IslemAdedi> islemAdedi()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_islemAdedi.FromSqlRaw($"SELECT  COUNT(islemno) AS [islemAdedi],count(case bipekkod3 WHEN 4 THEN 'ODENDI'end) gerceklesen FROM islemtakip WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE())\r\n   union all \r\n   SELECT  COUNT(islemno) AS [islemAdedi],count(case bipekkod3 WHEN 4 THEN 'ODENDI'end) gerceklesen FROM islemtakip WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) \r\n   union all \r\n SELECT  COUNT(islemno) AS [islemAdedi],count(case bipekkod3 WHEN 4 THEN 'ODENDI'end) gerceklesen FROM islemtakip WHERE year(islemtarihi) =year(GETDATE()) ").ToList();
                return data;
            }

        }

        public List<eko_IslemOnayDurumTutari> OnayDurumuTutari()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_IslemOnayDurumTutari.FromSqlRaw($"\r\n   SELECT TOP 100 OnayDurum AS onayDurumu, COALESCE(SUM(bordrotutar), 0) AS islemBordroTutari FROM (SELECT *, CASE onaylilikdurum           WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek'      Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE()) GROUP BY OnayDurum \r\n   union all\r\n   SELECT TOP 100 OnayDurum AS onayDurumu, COALESCE(SUM(bordrotutar), 0) AS islemBordroTutari FROM (SELECT *, CASE onaylilikdurum           WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek'      Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE())  GROUP BY OnayDurum \r\n   union all\r\n   SELECT TOP 100 OnayDurum AS onayDurumu, COALESCE(SUM(bordrotutar), 0) AS islemBordroTutari FROM (SELECT *, CASE onaylilikdurum           WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek'      Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) GROUP BY OnayDurum ").ToList();
                return data;
            }

        }

        public List<eko_ToplamBordroTutari> ToplamBordroTutari()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_ToplamBordroTutari.FromSqlRaw($" SELECT TOP 50000 COALESCE(SUM(bordrotutar), 0) AS [toplamBrodroTutari] FROM (SELECT *, CASE onaylilikdurum WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek' Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE())\r\n  union all\r\n  SELECT TOP 50000 COALESCE(SUM(bordrotutar), 0) AS [toplamBrodroTutari] FROM (SELECT *, CASE onaylilikdurum WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek' Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) \r\n   union all\r\n   SELECT TOP 50000 COALESCE(SUM(bordrotutar), 0) AS [toplamBrodroTutari] FROM (SELECT *, CASE onaylilikdurum WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek' Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) ").ToList();
                return data;
            }

        }

        public List<eko_SonIslemler> SonIslemler()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_SonIslemler.FromSqlRaw($"select top 10 islemno , firmano, firmaadi,kul.adi, bordrotutar,bipekkod4 from islemtakip it left join(select trim(bc.bipaciklama) aciklama,k.adi adi,k.id id from bipcodeparameters bc inner join  kullanici k on bc.bipekkod3 = k.id and k.aktif =1 where bipturu = 'DEPRT' and bc.bipaciklama <> 'İst-Beylikdüzü') kul on kul.aciklama = it.temsilcilik order by it.id desc").ToList();
                return data;
            }
            
        }


        public List<eko_PazarlamaciBilgileri> PazarlamaciBilgileri()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_PazarlamaciBilgileri.FromSqlRaw($"  select Trim(bc.bipaciklama) aciklama,k.adi adi,k.departman,sum(mb.risk) plasman, isnull(islemh.IslemHacmi,0) islemhacmi from bipcodeparameters bc inner join  kullanici k on bc.bipekkod3 = k.id and k.aktif =1 \r\n left join (select temsilci,risk from MusteriBilgileri) mb on mb.temsilci= k.id\r\n left join (select u.departman , sum(isnull(Tutar, 0)) IslemHacmi from eko_aysonuislemhacimleri i (nolock)  inner join firmadetay fd (nolock) on i.Firmano = fd.firmano   inner join kullanici u (nolock) on fd.temsilci = u.id   inner join bipcodeparameters b (nolock) on b.bipturu = 'DEPRT' and u.departman = b.bipkod  group by u.departman ) islemh on islemh.departman = k.departman\r\n where bipturu = 'DEPRT' and bc.bipaciklama <> 'İst-Beylikdüzü'   group by bc.bipaciklama,k.adi,k.departman,islemh.IslemHacmi ").ToList();
                return data;
            }

        }
        
        public List<eko_YeniMusteri> YeniMusteri()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_YeniMusteri.FromSqlRaw($"  select ReportMonth ay, count(distinct i.Firmano) Adet   \r\n  from eko_aysonuislemhacimleri i (nolock)  \r\n  inner join firmadetay fd (nolock) on i.Firmano = fd.firmano  \r\n  inner join kullanici u (nolock) on fd.temsilci = u.id  \r\n  inner join ( select bc.bipaciklama aciklama,k.adi adi,k.id id,k.departman dep from bipcodeparameters bc inner join  kullanici k on bc.bipekkod3 = k.id and k.aktif =1 where bipturu = 'DEPRT' and bc.bipaciklama <> 'İst-Beylikdüzü')k on k.dep = u.departman\r\n  where i.ReportYear = YEAR(GETDATE()) and Ekno in (301, 1) group by ReportMonth").ToList();
                return data;
            }

        }

        public List<eko_Ziyaret> Ziyaret()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_Ziyaret.FromSqlRaw($"select k.adi,count(*)ziyaret from eko_ziyaret ez left join kullanici k on k.kullanicikodu = ez.kullanicikodu where year(tarih) = Year(GETDATE()) and MONTH(tarih) = MONTH(GETDATE()) group by k.adi").ToList();
                return data;
            }

        }

        public List<eko_HedefData> HedefData()
        {
            using (var context = new dbsiriusContext())
            {
                var data = context.eko_HedefData.FromSqlRaw($"select * from eko_HedefT").ToList();
                return data;
            }
        }

        public List<eko_CekAdetleri> CekAdetleri()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_CekAdetleri.FromSqlRaw($"select k.adi,e.girenkullanici,COUNT(*) as girilencek from pesiniskontolar p left join eko_islemmaster e on p.islemno = e.islemno left join kullanici k on k.kullanicikodu = e.girenkullanici where year(islemtarihi) = year(GETDATE()) and MONTH(islemtarihi) = MONTH(GETDATE()) and day(islemtarihi) = 8 group by e.girenkullanici,k.adi ").ToList();
                return data;
            }
        }

        public bool HedefDataGuncelleme(eko_HedefDataUpdateModel model)
        {
            using (var context = new dbsiriusContext())
            {
                var result = context.eko_HedefData.FirstOrDefault(x=>x.id==model.id);
                if (result == null)
                {
                    return false;
                }

                result.hedef = model.hedef;

                context.eko_HedefData.Update(result);
                context.SaveChanges();
                return true;
            }

        }
    }
}