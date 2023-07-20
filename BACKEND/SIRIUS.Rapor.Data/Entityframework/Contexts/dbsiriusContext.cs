using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIRIUS.Rapor.Data.Models;

namespace SIRIUS.Rapor.Data.Entityframework.Contexts
{
    public class dbsiriusContext : IdentityDbContext<EkoUser,EkoRole,string>
    {
        public dbsiriusContext(DbContextOptions<dbsiriusContext> options):base(options)
        {
        }
    }
}