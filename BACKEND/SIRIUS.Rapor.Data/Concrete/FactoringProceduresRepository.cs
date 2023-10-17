using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Data.Abstract;
using SIRIUS.Rapor.Data.Entityframework.Contexts;
using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.Data.Concrete
{
    public class FactoringProceduresRepository : RepositoryBase_Factoring, IFactoringProceduresRepository
    {
        public FactoringProceduresRepository(dbfactoringContext context) : base(context) { }
        public async Task<List<eko_CekAdetleri>> CekAdetleri()
        {
            var data = await _context.eko_CekAdetleri.FromSqlRaw($"select k.adi,e.girenkullanici,COUNT(*) as girilencek from pesiniskontolar p left join eko_islemmaster e on p.islemno = e.islemno left join kullanici k on k.kullanicikodu = e.girenkullanici where year(islemtarihi) = year(GETDATE()) and MONTH(islemtarihi) = MONTH(GETDATE()) and day(islemtarihi) = 8 group by e.girenkullanici,k.adi ").ToListAsync();

            return data;
        }
        public async Task<List<eko_PazarlamaPerformansRaporu>> eko_PazarlamaPerformansRaporu(int yil, string kullanici = "csason")
        {
            var data = await _context.eko_PazarlamaPerformansRaporu.FromSqlRaw($"eko_PazarlamaPerformansRaporu {yil} , '{kullanici}'").ToListAsync();
            return data;
        }
        public async Task<List<eko_IslemAdedi>> islemAdedi()
        {
            var data = await _context.eko_islemAdedi.FromSqlRaw($"SELECT  COUNT(islemno) AS [islemAdedi],count(case bipekkod3 WHEN 4 THEN 'ODENDI'end) gerceklesen FROM islemtakip WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE())\r\n   union all \r\n   SELECT  COUNT(islemno) AS [islemAdedi],count(case bipekkod3 WHEN 4 THEN 'ODENDI'end) gerceklesen FROM islemtakip WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) \r\n   union all \r\n SELECT  COUNT(islemno) AS [islemAdedi],count(case bipekkod3 WHEN 4 THEN 'ODENDI'end) gerceklesen FROM islemtakip WHERE year(islemtarihi) =year(GETDATE()) ").ToListAsync();
            return data;
        }
        public async Task<List<eko_MusteriRiskListesi>> MusteriRiskListesi()
        {
            var data =await _context.eko_MusteriRiskListesi.FromSqlRaw($"select distinct f.firmano, f.adi musterit,fd.vergino,k.adi,riskB.bakiyesi, a.sehir, a.semt,a.adres from firma f \r\nleft join (select firmano ,max(sehir) sehir,max(semt) semt,max(adres) adres from adres where sehir is not null and semt is not null and adres is not null group by firmano) a on f.firmano = a.firmano  \r\nleft join firmadetay fd on fd.firmano=f.firmano \r\nleft join kullanici k on k.id=fd.temsilci\r\nright join  (select tarih , firmano , sum(cast( bakiye AS DECIMAL(18,2))) bakiyesi from eko_PazarlamaPerformansDetay where tarih =DateAdd(day,-1,convert(varchar, getdate(), 1)) group by firmano, tarih )riskB on riskB.firmano=f.firmano\r\nwhere k.aktif=1 ").ToListAsync();
            return data;
        }
        public async Task<IEnumerable<eko_MusteriRiskListesiMap>> MusteriRiskListesiMap(string user = "Hepsi")
        {
            if (user == "Hepsi")
            {
                var data =await _context.eko_MusteriRiskListesiMap.FromSqlRaw($"WITH a as (select distinct f.firmano, f.adi,fd.vergino,k.adi musterit,riskB.bakiyesi, a.sehir, a.semt,a.adres from firma f \r\nleft join (select firmano ,max(sehir) sehir,max(semt) semt,max(adres) adres from adres where sehir is not null and semt is not null and adres is not null group by firmano) a on f.firmano = a.firmano  \r\nleft join firmadetay fd on fd.firmano=f.firmano \r\nleft join kullanici k on k.id=fd.temsilci\r\nright join  (select tarih , firmano , sum(cast( bakiye AS DECIMAL(18,2))) bakiyesi from eko_PazarlamaPerformansDetay where tarih =DateAdd(day,-1,convert(varchar, getdate(), 1)) group by firmano, tarih )riskB on riskB.firmano=f.firmano\r\nwhere k.aktif=1) select sehir,semt,count(firmano) adet from a group by sehir,semt").ToListAsync();
                return data;
            }
            else if (user != "Hepsi")
            {
                var data =await _context.eko_MusteriRiskListesiMap.FromSqlRaw($"WITH a as (select distinct f.firmano, f.adi,fd.vergino,k.adi musterit,riskB.bakiyesi, a.sehir, a.semt,a.adres from firma f \r\nleft join (select firmano ,max(sehir) sehir,max(semt) semt,max(adres) adres from adres where sehir is not null and semt is not null and adres is not null group by firmano) a on f.firmano = a.firmano  \r\nleft join firmadetay fd on fd.firmano=f.firmano \r\nleft join kullanici k on k.id=fd.temsilci\r\nright join  (select tarih , firmano , sum(cast( bakiye AS DECIMAL(18,2))) bakiyesi from eko_PazarlamaPerformansDetay where tarih =DateAdd(day,-1,convert(varchar, getdate(), 1)) group by firmano, tarih )riskB on riskB.firmano=f.firmano\r\nwhere k.aktif=1) select sehir,semt,count(firmano) adet from a where musteriT='{user}' group by sehir,semt ").ToListAsync();
                return data;
            }
            return Enumerable.Empty <eko_MusteriRiskListesiMap>();
        }
        public async Task<List<eko_IslemOnayDurumTutari>> OnayDurumuTutari()
        {
            var data = await _context.eko_IslemOnayDurumTutari.FromSqlRaw($"\r\n   SELECT TOP 100 OnayDurum AS onayDurumu, COALESCE(SUM(bordrotutar), 0) AS islemBordroTutari FROM (SELECT *, CASE onaylilikdurum           WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek'      Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE()) GROUP BY OnayDurum \r\n   union all\r\n   SELECT TOP 100 OnayDurum AS onayDurumu, COALESCE(SUM(bordrotutar), 0) AS islemBordroTutari FROM (SELECT *, CASE onaylilikdurum           WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek'      Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE())  GROUP BY OnayDurum \r\n   union all\r\n   SELECT TOP 100 OnayDurum AS onayDurumu, COALESCE(SUM(bordrotutar), 0) AS islemBordroTutari FROM (SELECT *, CASE onaylilikdurum           WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek'      Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) GROUP BY OnayDurum ").ToListAsync();
            return data;
        }
        public async Task<List<eko_PazarlamaciBilgileri>> PazarlamaciBilgileri()
        {
            var data = await _context.eko_PazarlamaciBilgileri.FromSqlRaw($"select Trim(bc.bipaciklama) aciklama,k.adi adi,k.departman,sum(mb.risk) plasman, isnull(islemh.IslemHacmi,0) islemhacmi from bipcodeparameters bc \r\n inner join  kullanici k on bc.bipekkod3 = k.id and k.aktif =1  \r\n left join (select temsilci,risk from MusteriBilgileri) mb on mb.temsilci= k.id \r\n left join (select u.departman , sum(isnull(Tutar, 0)) IslemHacmi from eko_aysonuislemhacimleri i (nolock)  \r\n inner join firmadetay fd (nolock) on i.Firmano = fd.firmano   \r\n inner join kullanici u (nolock) on fd.temsilci = u.id   \r\n inner join bipcodeparameters b (nolock) on b.bipturu = 'DEPRT' and u.departman = b.bipkod \r\n where year(tarih) = year(GETDATE()) and MONTH(tarih) =month(GETDATE())\r\n group by u.departman ) islemh on islemh.departman = k.departman \r\n where bipturu = 'DEPRT' and bc.bipaciklama <> 'İst-Beylikdüzü' and mb.risk <> 0    \r\n group by bc.bipaciklama,k.adi,k.departman,islemh.IslemHacmi \r\n ").ToListAsync();
            return data;
        }
        public async Task<List<sel_eko_plasmandetay>> sel_eko_plasmandetay(int yil, int secim)
        {
            var data = await _context.sel_Eko_Plasmandetay.FromSqlRaw($"sel_eko_PlasmanDetay {yil} , {secim}").ToListAsync();
            return data;
        }
        public async Task<List<eko_SonIslemler>> SonIslemler()
        {
            var data =await _context.eko_SonIslemler.FromSqlRaw($"select top 10 islemno , firmano, firmaadi,kul.adi, bordrotutar,bipekkod4 from islemtakip it left join(select trim(bc.bipaciklama) aciklama,k.adi adi,k.id id from bipcodeparameters bc inner join  kullanici k on bc.bipekkod3 = k.id and k.aktif =1 where bipturu = 'DEPRT' and bc.bipaciklama <> 'İst-Beylikdüzü') kul on kul.aciklama = it.temsilcilik order by it.id desc").ToListAsync();
            return data;
        }
        public async Task<List<eko_ToplamBordroTutari>> ToplamBordroTutari()
        {
            var data = await _context.eko_ToplamBordroTutari.FromSqlRaw($" SELECT TOP 50000 COALESCE(SUM(bordrotutar), 0) AS [toplamBrodroTutari] FROM (SELECT *, CASE onaylilikdurum WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek' Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE())\r\n  union all\r\n  SELECT TOP 50000 COALESCE(SUM(bordrotutar), 0) AS [toplamBrodroTutari] FROM (SELECT *, CASE onaylilikdurum WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek' Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) \r\n   union all\r\n   SELECT TOP 50000 COALESCE(SUM(bordrotutar), 0) AS [toplamBrodroTutari] FROM (SELECT *, CASE onaylilikdurum WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek' Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) ").ToListAsync();
            return data;
        }
        public async Task<List<eko_YeniMusteri>> YeniMusteri()
        {
            var data =await _context.eko_YeniMusteri.FromSqlRaw($"  select ReportMonth ay, count(distinct i.Firmano) Adet   \r\n  from eko_aysonuislemhacimleri i (nolock)  \r\n  inner join firmadetay fd (nolock) on i.Firmano = fd.firmano  \r\n  inner join kullanici u (nolock) on fd.temsilci = u.id  \r\n  inner join ( select bc.bipaciklama aciklama,k.adi adi,k.id id,k.departman dep from bipcodeparameters bc inner join  kullanici k on bc.bipekkod3 = k.id and k.aktif =1 where bipturu = 'DEPRT' and bc.bipaciklama <> 'İst-Beylikdüzü')k on k.dep = u.departman\r\n  where i.ReportYear = YEAR(GETDATE()) and Ekno in (301, 1) group by ReportMonth").ToListAsync();
            return data;
        }
        public async Task<List<eko_Ziyaret>> Ziyaret()
        {
            var data =await _context.eko_Ziyaret.FromSqlRaw($"select k.adi,count(*)ziyaret from eko_ziyaret ez left join kullanici k on k.kullanicikodu = ez.kullanicikodu where year(tarih) = Year(GETDATE()) and MONTH(tarih) = MONTH(GETDATE()) group by k.adi").ToListAsync();
            return data;
        }
    }
}