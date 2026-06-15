using Farmacorp.POSExpress.Dominio.Models.Express;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Dominio.Models.Erp
{
    public class ErpProductos
    {
        public int IdProducto { get; set; }
        public decimal Costo { get; set; }
        public string UniqueCodigo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Stock { get; set; }

        public ExpProductos ProductoExpress { get; set; }


    }
}
