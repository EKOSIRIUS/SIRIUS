using SharedLibrary.Configurations;
using SIRIUS.Rapor.Business.Extensions;
using SharedLibrary.Extensions;
using Microsoft.OpenApi.Models;

namespace SIRIUS.Rapor.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.LoadMyService(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Kimliğiniz ile doğrulayın.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Description = "Authorize: Bearer {JWT}"
                        },
                        new string[] {  }
                    }
                });
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
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