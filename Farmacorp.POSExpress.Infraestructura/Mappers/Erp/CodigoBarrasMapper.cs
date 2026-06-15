using Farmacorp.POSExpress.Dominio.Models.Erp;
using Farmacorp.POSExpress.Infraestructura.Entities.Erp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Infraestructura.Mappers.Erp
{
    public static class CodigoBarrasMapper
    {
        public static CodigoBarras ToDomain(CodigoBarraEntity entity)
        {
            return new CodigoBarras
            {
                IdCodigoBarra = entity.IdCodigoBarra,
                UniqueCodigo = entity.UniqueCodigo,
                Activo = entity.Activo,
                IdProducto = entity.IdProducto
            };
        }

        public static CodigoBarraEntity ToEntity(CodigoBarras model)
        {
            return new CodigoBarraEntity
            {
                IdCodigoBarra = model.IdCodigoBarra,
                UniqueCodigo = model.UniqueCodigo,
                Activo = model.Activo,
                IdProducto = model.IdProducto
            };
        }
    }
}
