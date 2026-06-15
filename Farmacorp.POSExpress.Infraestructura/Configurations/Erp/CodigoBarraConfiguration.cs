using Farmacorp.POSExpress.Infraestructura.Entities.Erp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Infraestructura.Configurations.Erp
{
    public class CodigoBarraConfiguration : IEntityTypeConfiguration<CodigoBarraEntity>
    {
        public void Configure(EntityTypeBuilder<CodigoBarraEntity> builder) 
        {
            builder.ToTable("CodigosBarras");

            builder.HasKey(x => x.IdCodigoBarra);
            builder.Property(x => x.UniqueCodigo)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Activo)
                .IsRequired();

            //codigo de barra - producto
            builder.HasOne(x => x.Producto)
                .WithMany(x => x.CodigosBarras)
                .HasForeignKey(x => x.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
