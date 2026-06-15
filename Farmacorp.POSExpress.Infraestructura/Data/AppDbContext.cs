

using Farmacorp.POSExpress.Infraestructura.Entities.Erp;
using Farmacorp.POSExpress.Infraestructura.Entities.Express;
using Microsoft.EntityFrameworkCore
    ;

namespace Farmacorp.POSExpress.Infraestructura.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option): base(option)
        {
        }
        // EXPRESS

        public DbSet<ProductoEntity> Productos { get; set; }

        public DbSet<TipoProductoEntity> TiposProducto { get; set; }

        public DbSet<CategoriaEntity> Categorias { get; set; }

        public DbSet<ProductoCategoriaEntity> ProductosCategorias { get; set; }

        public DbSet<VentaExpressEntity> VentasExpress { get; set; }



        // ERP

        public DbSet<ProductoERPEntity> ProductosERP { get; set; }

        public DbSet<CodigoBarraEntity> CodigosBarras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly
            );

            // Seed Data de los casos de prueba desde un archivo externo
            modelBuilder.SeedData();
        }

    }
}
