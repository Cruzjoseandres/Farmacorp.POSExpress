using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Dominio.Models.Erp
{
    public class CodigoBarras
    {
        public int IdCodigoBarra { get; set; }
        public string UniqueCodigo { get; set; }
        public bool Activo { get; set; }
        public int IdProducto { get; set; }
        public ErpProductos Producto { get; set; }
    }
}
