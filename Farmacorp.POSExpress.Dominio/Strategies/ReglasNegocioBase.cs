using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Dominio.Strategies
{
    public class ReglasNegocioBase : IReglasNegocio
    {
        public decimal CalcularDescuento(decimal precio, int cantidadCategorias)
        {
            if (cantidadCategorias == 1)
            {
                return precio * 0.30m; // 30% de descuento
            }
            return 0; // Sin descuento
        }

        public decimal CalcularPrecio(decimal costo)
        {
            return costo * 1.5m; //margen del 50% sobre el costo
        }

        public bool ValidarStock(int stockActual, int cantidadSolicitada)
        {
            return stockActual >= cantidadSolicitada; // Retorna true si hay suficiente stock, false si no lo hay
        }
    }
}
