using SharedLibrary.Configurations;
using SIRIUS.Rapor.Business.Extensions;
using SharedLibrary.Extensions;

namespace SIRIUS.Rapor.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.LoadMyService(builder.Environment.IsDevelopment(),builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5500")// Ýzin vermek istediðiniz kökeni burada belirtin
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));
            var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
            builder.Services.AddCustomTokenAuth(tokenOptions);

            var app = builder.Build();
            app.UseCors("AllowSpecificOrigin");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}