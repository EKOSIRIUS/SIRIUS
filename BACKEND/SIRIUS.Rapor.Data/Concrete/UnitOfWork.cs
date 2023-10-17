using SIRIUS.Rapor.Data.Abstract;
using SIRIUS.Rapor.Data.Entityframework.Contexts;

namespace SIRIUS.Rapor.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly dbfactoringContext dbfactoringContext;
        private readonly dbsiriusContext dbsiriusContext;
        private FactoringProceduresRepository _factoringProceduresRepository;
        private SiriusProceduresRepository _siriusProceduresRepository;
        public UnitOfWork(dbfactoringContext dbfactoringContext, dbsiriusContext dbsiriusContext)
        {
            this.dbfactoringContext = dbfactoringContext;
            this.dbsiriusContext = dbsiriusContext;
        }
        public IFactoringProceduresRepository FactoringProceduresRepository => _factoringProceduresRepository ??= new FactoringProceduresRepository(dbfactoringContext);
        public ISiriusProceduresRepository SiriusProceduresRepository => _siriusProceduresRepository ??= new SiriusProceduresRepository(dbsiriusContext);
        public void Dispose()
        {
            dbfactoringContext.Dispose();
            dbsiriusContext.Dispose();
        }
        public async Task<int> FactoringSaveChangeAsync()
        {
            return await dbfactoringContext.SaveChangesAsync();
        }
        public async Task<int> SiriusSaveChangeAsync()
        {
            return await dbsiriusContext.SaveChangesAsync();
        }
    }
}