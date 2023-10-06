using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Data.Models
{
    public class eko_HedefData
    {
        [Key]
        public int id { get; set; }
        public string? aciklama { get; set; }
        public decimal hedef { get; set; }

    }
}
