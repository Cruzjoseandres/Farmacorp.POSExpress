using Farmacorp.POSExpress.Infraestructura.Entities.Erp;
using Farmacorp.POSExpress.Infraestructura.Entities.Express;
using Microsoft.EntityFrameworkCore;
using System;

namespace Farmacorp.POSExpress.Infraestructura.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // 1. Tipos de Producto base
            modelBuilder.Entity<TipoProductoEntity>().HasData(
                new TipoProductoEntity { IdTipoProducto = 1, Descripcion = "General" }
            );

            // 2. Categorías base (necesitamos al menos 2 para probar el Producto B)
            modelBuilder.Entity<CategoriaEntity>().HasData(
                new CategoriaEntity { IdCategoria = 1, Descripcion = "Categoría Principal", Activo = true },
                new CategoriaEntity { IdCategoria = 2, Descripcion = "Categoría Secundaria", Activo = true }
            );

            // 3. Productos (Módulo Express)
            // Se inicializan con Precio 0 porque el precio real se calcula con el servicio usando la Regla de Negocio
            modelBuilder.Entity<ProductoEntity>().HasData(
                new ProductoEntity { IdProducto = 1, Nombre = "Producto A", Precio = 0m, Activo = true, FechaVencimiento = DateTime.Now.AddYears(1), Observaciones = "Test A", IdTipoProducto = 1 },
                new ProductoEntity { IdProducto = 2, Nombre = "Producto B", Precio = 0m, Activo = true, FechaVencimiento = DateTime.Now.AddYears(1), Observaciones = "Test B", IdTipoProducto = 1 },
                new ProductoEntity { IdProducto = 3, Nombre = "Producto C", Precio = 0m, Activo = true, FechaVencimiento = DateTime.Now.AddYears(1), Observaciones = "Test C", IdTipoProducto = 1 },
                new ProductoEntity { IdProducto = 4, Nombre = "Producto D", Precio = 0m, Activo = true, FechaVencimiento = DateTime.Now.AddYears(1), Observaciones = "Test D", IdTipoProducto = 1 },
                new ProductoEntity { IdProducto = 5, Nombre = "Producto E", Precio = 0m, Activo = true, FechaVencimiento = DateTime.Now.AddYears(1), Observaciones = "Test E", IdTipoProducto = 1 }
            );

            // 4. Productos ERP (Costos y Stock - Los casos de prueba solicitados)
            modelBuilder.Entity<ProductoERPEntity>().HasData(
                new ProductoERPEntity { IdProducto = 1, Costo = 100m, Stock = 15, UniqueCodigo = "ERP-A001", FechaRegistro = DateTime.Now },
                new ProductoERPEntity { IdProducto = 2, Costo = 100m, Stock = 15, UniqueCodigo = "ERP-B002", FechaRegistro = DateTime.Now },
                new ProductoERPEntity { IdProducto = 3, Costo = 100m, Stock = 0, UniqueCodigo = "ERP-C003", FechaRegistro = DateTime.Now },
                new ProductoERPEntity { IdProducto = 4, Costo = 100m, Stock = 11, UniqueCodigo = "ERP-D004", FechaRegistro = DateTime.Now },
                new ProductoERPEntity { IdProducto = 5, Costo = 100m, Stock = 12, UniqueCodigo = "ERP-E005", FechaRegistro = DateTime.Now }
            );

            // 5. Asignación de Categorías (ProductoCategoriaEntity)
            modelBuilder.Entity<ProductoCategoriaEntity>().HasData(
                // Producto A: 1 sola categoría
                new ProductoCategoriaEntity { IdDetalle = 1, IdProducto = 1, IdCategoria = 1, FechaCreacion = DateTime.Now },
                
                // Producto B: 2 categorías diferentes
                new ProductoCategoriaEntity { IdDetalle = 2, IdProducto = 2, IdCategoria = 1, FechaCreacion = DateTime.Now },
                new ProductoCategoriaEntity { IdDetalle = 3, IdProducto = 2, IdCategoria = 2, FechaCreacion = DateTime.Now },
                
                // Producto C: 1 sola categoría
                new ProductoCategoriaEntity { IdDetalle = 4, IdProducto = 3, IdCategoria = 1, FechaCreacion = DateTime.Now },
                
                // Producto D: 1 sola categoría
                new ProductoCategoriaEntity { IdDetalle = 5, IdProducto = 4, IdCategoria = 1, FechaCreacion = DateTime.Now },
                
                // Producto E: 1 sola categoría
                new ProductoCategoriaEntity { IdDetalle = 6, IdProducto = 5, IdCategoria = 1, FechaCreacion = DateTime.Now }
            );
        }
    }
}
