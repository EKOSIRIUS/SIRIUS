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

            return new List<eko_PazarlamaPerformansRaporu>();
        }
        public List<sel_eko_plasmandetay> sel_eko_plasmandetay(int yil,int secim)
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.sel_Eko_Plasmandetay.FromSqlRaw($"sel_eko_PlasmanDetay {yil} , {secim}").ToList();
                return data;
            }

            return new List<sel_eko_plasmandetay>();
        }
        public List<eko_IslemAdedi> islemAdedi()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_islemAdedi.FromSqlRaw($"SELECT TOP 50000 COALESCE(COUNT(islemno), 0) AS [islemAdedi] FROM (SELECT *, CASE onaylilikdurum WHEN 1 THEN 'Onaylandı'         ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek' Else 'Onaylı - ?'           End END as OdemeDurum from islemtakip (nolock)  where year(islemtarihiyil) = year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE()) ;").ToList();
                return data;
            }

            return new List<eko_IslemAdedi>();
        }

        public List<eko_IslemOnayDurumTutari> OnayDurumuTutari()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_IslemOnayDurumTutari.FromSqlRaw($"SELECT TOP 100 OnayDurum AS onayDurumu, COALESCE(SUM(bordrotutar), 0) AS islemBordroTutari FROM (SELECT *, CASE onaylilikdurum           WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek'      Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table WHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE()) GROUP BY OnayDurum ORDER BY islemBordroTutari DESC;").ToList();
                return data;
            }

            return new List<eko_IslemOnayDurumTutari>();
        }

        public List<eko_ToplamBordroTutari> ToplamBordroTutari()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_ToplamBordroTutari.FromSqlRaw($"SELECT TOP 50000 COALESCE(SUM(bordrotutar), 0) AS [toplamBrodroTutari] FROM (SELECT *, CASE onaylilikdurum WHEN 1 THEN 'Onaylandı' ELse 'Onaylanmadı' END as OnayDurum, CASE bipekkod3 When 4 Then 'Ödendi, Gerçekleşti' Else CASE onaylilikdurum when 0 Then 'Onaysız - Gerçekleşmeyecek' Else 'Onaylı - ?' End END as OdemeDurum from islemtakip (nolock) where islemtarihiyil >= year(GETDATE())) AS virtual_table\r\nWHERE year(islemtarihi) =year(GETDATE()) and MONTH(islemtarihi) =month(GETDATE()) and day(islemtarihi) = day(GETDATE());").ToList();
                return data;
            }

            return new List<eko_ToplamBordroTutari>();
        }

        public List<eko_SonIslemler> SonIslemler()
        {
            using (var context = new dbfactoringContext())
            {
                var data = context.eko_SonIslemler.FromSqlRaw($"select top 10 islemno , firmano, firmaadi, bordrotutar,bipekkod4 from islemtakip order by id desc").ToList();
                return data;
            }

            return new List<eko_SonIslemler>();
        }
    }
}