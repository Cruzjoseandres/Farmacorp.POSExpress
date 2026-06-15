using Farmacorp.POSExpress.Infraestructura.Entities.Express;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Infraestructura.Entities.Erp
{
    public class CodigoBarraEntity
    {
        public int IdCodigoBarra { get; set; }
        public string UniqueCodigo { get; set; }
        public bool Activo { get; set; }

        public int IdProducto { get; set; }
        public ProductoEntity Producto { get; set; }
    }
}
