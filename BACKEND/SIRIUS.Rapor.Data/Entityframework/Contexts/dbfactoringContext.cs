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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=172.34.1.15;Initial Catalog=dbfactoringtest;Persist Security Info=False;User ID=bisuser;Password=p@ssword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eko_PazarlamaPerformansRaporu>().HasNoKey();
            modelBuilder.Entity<sel_eko_plasmandetay>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}