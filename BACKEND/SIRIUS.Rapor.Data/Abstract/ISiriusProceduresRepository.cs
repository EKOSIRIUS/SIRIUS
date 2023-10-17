using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.Data.Abstract
{
    public interface ISiriusProceduresRepository
    {
        Task<List<EkoHedefT>> HedefData();
        Task<bool> HedefDataGuncelleme(eko_HedefDataUpdateModel model);
    }
}