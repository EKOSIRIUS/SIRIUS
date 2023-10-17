using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.Data.Entityframework.Contexts
{
    public class dbfactoringContext : DbContext
    {
        public dbfactoringContext(DbContextOptions<dbfactoringContext> options):base(options) { }
        public DbSet<eko_PazarlamaPerformansRaporu> eko_PazarlamaPerformansRaporu { get; set; }
        public DbSet<sel_eko_plasmandetay> sel_Eko_Plasmandetay { get; set; }
        public DbSet<eko_IslemAdedi> eko_islemAdedi { get; set; }
        public DbSet<eko_IslemOnayDurumTutari> eko_IslemOnayDurumTutari { get; set; }
        public DbSet<eko_ToplamBordroTutari> eko_ToplamBordroTutari { get; set; }
        public DbSet<eko_SonIslemler> eko_SonIslemler { get; set; }
        public DbSet<eko_PazarlamaciBilgileri> eko_PazarlamaciBilgileri { get; set; }
        public DbSet<eko_YeniMusteri> eko_YeniMusteri { get; set; }
        public DbSet<eko_Ziyaret> eko_Ziyaret { get; set; }
        public DbSet<eko_CekAdetleri> eko_CekAdetleri { get; set; }
        public DbSet<eko_MusteriRiskListesi> eko_MusteriRiskListesi { get; set; }
        public DbSet<eko_MusteriRiskListesiMap> eko_MusteriRiskListesiMap { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eko_PazarlamaPerformansRaporu>().HasNoKey();
            modelBuilder.Entity<sel_eko_plasmandetay>().HasNoKey();
            modelBuilder.Entity<eko_IslemAdedi>().HasNoKey();
            modelBuilder.Entity<eko_IslemOnayDurumTutari>().HasNoKey();
            modelBuilder.Entity<eko_ToplamBordroTutari>().HasNoKey();
            modelBuilder.Entity<eko_SonIslemler>().HasNoKey();
            modelBuilder.Entity<eko_PazarlamaciBilgileri>().HasNoKey();
            modelBuilder.Entity<eko_YeniMusteri>().HasNoKey();
            modelBuilder.Entity<eko_Ziyaret>().HasNoKey();
            modelBuilder.Entity<eko_CekAdetleri>().HasNoKey();
            modelBuilder.Entity<eko_MusteriRiskListesi>().HasNoKey();
            modelBuilder.Entity<eko_MusteriRiskListesiMap>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}