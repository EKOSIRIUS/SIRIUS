using SIRIUS.Rapor.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Entity.Concrete 
{
    public class eko_IslemAdedi : IEntity
    {
        public int islemAdedi { get; set; }
        public int gerceklesen { get; set; }
    }
}
