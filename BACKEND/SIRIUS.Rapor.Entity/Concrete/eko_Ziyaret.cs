using SIRIUS.Rapor.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Entity.Concrete
{
    public class eko_Ziyaret : IEntity
    {
        public string adi { get; set; }
        public int ziyaret { get; set; }
    }
}
