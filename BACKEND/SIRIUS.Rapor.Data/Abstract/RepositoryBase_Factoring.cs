using SIRIUS.Rapor.Data.Entityframework.Contexts;

namespace SIRIUS.Rapor.Data.Abstract
{
    public abstract class RepositoryBase_Factoring
    {
        protected readonly dbfactoringContext _context;
        protected RepositoryBase_Factoring(dbfactoringContext context)
        {
            _context = context;
        }
    }
}