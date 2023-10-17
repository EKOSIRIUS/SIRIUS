using SIRIUS.Rapor.Entity.Abstract;

namespace SIRIUS.Rapor.Entity.Concrete
{
    public class eko_HedefDataUpdateModel : IEntity
    {
        public int id { get; set; }
        public decimal hedef { get; set; }

    }
}