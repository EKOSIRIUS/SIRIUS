using SIRIUS.Rapor.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Entity.Concrete
{
    public class eko_PazarlamaPerformansRaporu : IEntity
    {
        public int ReportYear { get; set; }
        public int ReportMonth { get; set; }
        public decimal Plasman { get; set; }
        public decimal OrtalamaPlasman { get; set; }
        public decimal PlasmanKatkiliOran { get; set; }
        public decimal PlasmanOrtlamaVade { get; set; }
        public decimal Gelir { get; set; }
        public decimal Yuzde { get; set; }
        public decimal Ortgelir { get; set; }
        public decimal Aktif { get; set; }
        public int PlasmanMusteriAdedi { get; set; }
        public decimal IslemHacmi { get; set; }
        public decimal IslemKatkiliOran { get; set; }
        public decimal IslemOrtlamaVade { get; set; }
        public int IslemMusteriAdedi { get; set; }
        public decimal ilk10MusteriRisk { get; set; }
        public decimal ilk20MusteriRisk { get; set; }
        public decimal GrupPlasman { get; set; }
        public decimal GrupIciIslem { get; set; }
        public decimal Kit { get; set; }
        public decimal KitTahsilat { get; set; }
        public int YeniIslemMusteriAdedi { get; set; }
        public decimal YeniIslemMusteriTutari { get; set; }
        public int KumulatifIslemAdedi { get; set; }
        public decimal KumulatifMusteriTutari { get; set; }
        public decimal KrediMaliyet { get; set; }
        public decimal KrediVade { get; set; }
        public decimal BonoMaliyet { get; set; }
        public decimal PasifMaliyet { get; set; }
        public decimal PasifVade { get; set; }
        public int AdayMusteriZiyaretAdedi { get; set; }
    }
}