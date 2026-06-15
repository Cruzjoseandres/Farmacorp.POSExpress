using Farmacorp.POSExpress.Aplicacion.Interfaces.Erp;
using Farmacorp.POSExpress.Aplicacion.Interfaces.Express;
using Farmacorp.POSExpress.Aplicacion.Services.Erp;
using Farmacorp.POSExpress.Aplicacion.Services.Express;
using Farmacorp.POSExpress.Dominio.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace Farmacorp.POSExpress.Aplicacion
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplicacion(
            this IServiceCollection services)
        {
            // Estrategia activa - cambiar aquí para alternar entre Base y GanaMax
            services.AddScoped<IReglasNegocio, ReglasNegocioBase>();
            // services.AddScoped<IReglasNegocio, ReglasNegocioGanaMax>();


            // Servicios
            services.AddScoped<IErpProductoService, ErpProductoService>();
            services.AddScoped<ICodigoBarrasService, CodigoBarrasService>();
            services.AddScoped<IProductoCategoriaService, ProductoCategoriaService>();
            services.AddScoped<IVentaExpressService, VentaExpressService>();
            services.AddScoped<IExpProductoService, ExpProductoService>();
            return services;
        }
    }
}
