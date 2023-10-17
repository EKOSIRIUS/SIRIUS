using SIRIUS.Rapor.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Entity.Concrete
{
    public class eko_PazarlamaciBilgileri : IEntity
    {
        public string aciklama { get; set; }
        public string adi { get; set; }
        public byte departman { get; set; }
        public decimal plasman { get; set; }
        public decimal IslemHacmi { get; set; }
    }
}
