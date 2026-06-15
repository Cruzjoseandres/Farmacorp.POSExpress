using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Dominio.Strategies
{
    public class ReglasNegocioGanaMax : IReglasNegocio
    {
        public decimal CalcularDescuento(decimal precio, int cantidadCategorias)
        {
            if (cantidadCategorias == 1)
            {
                return precio * 0.10m; // 10% de descuento
            }
            return 0; // Sin descuento
        }

        public decimal CalcularPrecio(decimal costo)
        {
            return costo * 1.8m; //margen del 80% sobre el costo
        }

        public bool ValidarStock(int stockActual, int cantidadSolicitada)
        {
            return (stockActual - cantidadSolicitada) >= 10; //solo dejar si hay 10 unidades o mas despues de vender
        }
    }
}
