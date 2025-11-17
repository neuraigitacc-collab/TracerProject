using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracer.Domain.Contracts;
using Tracer.Infrastructure.Context;
using Tracer.Infrastructure.Repositories;

namespace Tracer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var cs = config.GetConnectionString("Default")
                     ?? "Host=localhost;Port=5432;Database=Tracerdb;Username=postgres;Password=Ali3uzuki@";

             services.AddDbContext<AppDbContext>(opt =>
                 opt.UseNpgsql(cs)); // .UseSnakeCaseNamingConvention() در صورت تمایل
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            return services;
        }
    }
}