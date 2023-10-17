using SIRIUS.Rapor.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Entity.Concrete
{
    public class eko_SonIslemler : IEntity
    {
        public int islemno { get; set; }
        public int firmano { get; set; }
        public string firmaadi { get; set; }
        public string adi { get; set; }
        public double bordrotutar { get; set; }
        public string bipekkod4 { get; set; }
    }
}
