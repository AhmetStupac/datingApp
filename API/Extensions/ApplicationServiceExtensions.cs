using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.ApplicationServiceExtensions
{
    public static class ApplicationServiceExtensions //mora biti staticna metoda
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyHeader()
                              .AllowAnyOrigin()
                              .AllowAnyMethod();
                    });
            });

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

    }
}
