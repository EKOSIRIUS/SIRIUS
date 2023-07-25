using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIRIUS.Rapor.Data.Entityframework.Contexts
{
    public class dbfactoringContext : DbContext
    {
        public dbfactoringContext()
        {

        }
        public dbfactoringContext(DbContextOptions<dbfactoringContext> options):base(options)
        {
        }
        public DbSet<eko_PazarlamaPerformansRaporu> eko_PazarlamaPerformansRaporu { get; set; }
        public DbSet<sel_eko_plasmandetay> sel_Eko_Plasmandetay { get; set; }
        public DbSet<eko_IslemAdedi> eko_islemAdedi { get; set; }
        public DbSet<eko_IslemOnayDurumTutari> eko_IslemOnayDurumTutari { get; set; }
        public DbSet<eko_ToplamBordroTutari> eko_ToplamBordroTutari { get; set; }
        public DbSet<eko_SonIslemler> eko_SonIslemler { get; set; }
        public DbSet<eko_PazarlamaPlasman> eko_PazarlamaPlasman { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=172.34.1.15;Initial Catalog=dbfactoringtest;Persist Security Info=False;User ID=bisuser;Password=p@ssword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
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
            modelBuilder.Entity<eko_PazarlamaPlasman>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}