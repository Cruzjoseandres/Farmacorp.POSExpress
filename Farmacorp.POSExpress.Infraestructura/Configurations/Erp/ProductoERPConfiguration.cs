using Farmacorp.POSExpress.Infraestructura.Entities.Erp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Infraestructura.Configurations.Erp
{
    public class ProductoERPConfiguration : IEntityTypeConfiguration<ProductoERPEntity>
    {
        public void Configure(EntityTypeBuilder<ProductoERPEntity> builder)
        {
            builder.ToTable("ProductosERP");
            builder.HasKey(x => x.IdProducto);
            builder.Property(x => x.Costo)
                .HasColumnType("decimal(18,2)");
            builder.Property(x => x.UniqueCodigo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Stock)
                .IsRequired();

            builder.Property(x => x.FechaRegistro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(x => x.Producto)
                .WithOne(x => x.ProductoERP)
                .HasForeignKey<ProductoERPEntity>(x => x.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
