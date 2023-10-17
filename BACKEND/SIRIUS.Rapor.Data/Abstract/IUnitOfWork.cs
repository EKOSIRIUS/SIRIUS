namespace SIRIUS.Rapor.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IFactoringProceduresRepository FactoringProceduresRepository { get; }
        ISiriusProceduresRepository SiriusProceduresRepository { get; }
        Task<int> FactoringSaveChangeAsync();
        Task<int> SiriusSaveChangeAsync();
    }
}