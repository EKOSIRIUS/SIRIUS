using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Data.Models
{
    public class eko_PazarlamaciIslemHacimleri
    {
        public string aciklama { get; set; }
        public string adi { get; set; }
        public byte departman { get; set; }
        public decimal IslemHacmi { get; set; }
    }
}
