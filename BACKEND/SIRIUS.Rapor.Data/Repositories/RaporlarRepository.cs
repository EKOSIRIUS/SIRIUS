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
    }
}