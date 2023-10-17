using SIRIUS.Rapor.Data.Abstract;

namespace SIRIUS.Rapor.Business.Abstract
{
    public abstract class ServiceBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}