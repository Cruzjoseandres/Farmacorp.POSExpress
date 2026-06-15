using Farmacorp.POSExpress.Dominio.Interfaces;
using Farmacorp.POSExpress.Infraestructura.Data;
using Farmacorp.POSExpress.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Farmacorp.POSExpress.Infraestructura
{
    /// <summary>
    /// Extensión para registrar los servicios de infraestructura en el contenedor de inyección de dependencias
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registra los servicios de base de datos
        /// </summary>
        public static IServiceCollection AddInfraestructura(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Registrar DbContext con SQL Server
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                )
            );
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
