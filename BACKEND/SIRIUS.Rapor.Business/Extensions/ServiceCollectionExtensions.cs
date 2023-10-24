using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIRIUS.Rapor.Business.Abstract;
using SIRIUS.Rapor.Business.Concrete;
using SIRIUS.Rapor.Data.Abstract;
using SIRIUS.Rapor.Data.Concrete;
using SIRIUS.Rapor.Data.Entityframework.Contexts;

namespace SIRIUS.Rapor.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection services,IConfiguration confg)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRaporlarService, RaporlarService>();
            services
                .AddDbContext<dbfactoringContext>(options =>
                {
                    options.UseSqlServer(confg.GetConnectionString("dbfactoringtest"));
                })
                .AddDbContext<dbsiriusContext>(options =>
                {
                    options.UseSqlServer(confg.GetConnectionString("dbsirius"));
                });

            return services;
        }
    }
}