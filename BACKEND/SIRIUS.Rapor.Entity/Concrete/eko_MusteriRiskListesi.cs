﻿using SIRIUS.Rapor.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Entity.Concrete
{
    public class eko_MusteriRiskListesi : IEntity
    {
        public int firmano { get; set; }
        public string adi { get; set; }
        public string vergino { get; set; }
        public string musterit { get; set; }
        public decimal bakiyesi { get; set; }
        public string sehir { get; set; }
        public string semt { get; set; }
        public string adres { get; set; }
    }
}
