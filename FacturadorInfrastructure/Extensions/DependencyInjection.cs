using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FacturadorDomain.Repositories;
using FacturadorInfrastructure.Repositories;
using FacturadorInfrastructure.Context;
using Microsoft.Extensions.Configuration;

namespace FacturadorInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<IFacturaCabeceraRepository, FacturaCabeceraRepository>();
            services.AddScoped<IFacturaDetalleRepository, FacturaDetalleRepository>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();
            return services;
        }
    }
}
