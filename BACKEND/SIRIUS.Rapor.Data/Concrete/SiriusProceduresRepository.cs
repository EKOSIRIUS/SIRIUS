using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Data.Abstract;
using SIRIUS.Rapor.Data.Entityframework.Contexts;
using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.Data.Concrete
{
    public class SiriusProceduresRepository : RepositoryBase_Sirius, ISiriusProceduresRepository
    {
        public SiriusProceduresRepository(dbsiriusContext context) : base(context) { }
        public async Task<List<EkoHedefT>> HedefData()
        {
            var result = await _context.EkoHedefT.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<bool> HedefDataGuncelleme(eko_HedefDataUpdateModel model)
        {
            var result = await _context.EkoHedefT.FirstOrDefaultAsync(x => x.Id == model.id); 
            
            if (result == null) return false;

            _context.EkoHedefT.Update(result);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}