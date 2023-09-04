using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Data.Models;

namespace SIRIUS.Rapor.Data.Entityframework.Contexts
{
    public class dbsiriusContext : IdentityDbContext<EkoUser,EkoRole,string>
    {
        public dbsiriusContext()
        {
            
        }
        public dbsiriusContext(DbContextOptions<dbsiriusContext> options):base(options)
        {

        }

        public DbSet<eko_HedefData> eko_HedefData { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=172.34.1.15;Initial Catalog=dbsirius;Persist Security Info=False;User ID=bisuser;Password=p@ssword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eko_HedefData>().ToTable("eko_HedefT");
            base.OnModelCreating(modelBuilder);
        }
    }
}