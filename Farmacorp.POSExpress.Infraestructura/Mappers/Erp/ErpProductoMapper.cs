using Farmacorp.POSExpress.Dominio.Models.Erp;
using Farmacorp.POSExpress.Infraestructura.Entities.Erp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Infraestructura.Mappers.Erp
{
    public static class ErpProductoMapper
    {
        public static ErpProductos ToDomain(ProductoERPEntity entity)
        {
            return new ErpProductos
            {
                IdProducto = entity.IdProducto,
                Costo = entity.Costo,
                UniqueCodigo = entity.UniqueCodigo,
                FechaRegistro = entity.FechaRegistro,
                Stock = entity.Stock,
            };
        }

        public static ProductoERPEntity ToEntity(ErpProductos model)
        {
            return new ProductoERPEntity
            {
                IdProducto = model.IdProducto,
                Costo = model.Costo,
                UniqueCodigo = model.UniqueCodigo,
                FechaRegistro = model.FechaRegistro,
                Stock = model.Stock,
            };
        }
    }
}
