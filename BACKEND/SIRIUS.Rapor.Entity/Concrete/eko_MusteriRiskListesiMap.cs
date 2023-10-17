using SIRIUS.Rapor.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Entity.Concrete
{
    public class eko_MusteriRiskListesiMap : IEntity
    {
        public string sehir { get; set; }
        public string semt { get; set; }
        public int adet { get; set; }

    }
}
