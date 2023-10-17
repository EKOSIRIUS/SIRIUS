using SIRIUS.Rapor.Data.Entityframework.Contexts;

namespace SIRIUS.Rapor.Data.Abstract
{
    public abstract class RepositoryBase_Sirius
    {
        protected readonly dbsiriusContext _context;
        protected RepositoryBase_Sirius(dbsiriusContext context)
        {
            _context = context;
        }
    }
}