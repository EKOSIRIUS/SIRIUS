using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Entity.Concrete;

namespace SIRIUS.Rapor.Data.Entityframework.Contexts
{
    public class dbsiriusContext : DbContext
    {
        public dbsiriusContext(DbContextOptions<dbsiriusContext> options):base(options) { }
        public DbSet<EkoHedefT> EkoHedefT { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}