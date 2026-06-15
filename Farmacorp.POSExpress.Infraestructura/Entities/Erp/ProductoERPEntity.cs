using Farmacorp.POSExpress.Infraestructura.Entities.Express;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Infraestructura.Entities.Erp
{
    public class ProductoERPEntity
    {
        public int IdProducto { get; set; }
        public decimal Costo { get; set; }
        public string UniqueCodigo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Stock { get; set; }

        // FK 1-1
        public ProductoEntity Producto { get; set; }
    }
}
