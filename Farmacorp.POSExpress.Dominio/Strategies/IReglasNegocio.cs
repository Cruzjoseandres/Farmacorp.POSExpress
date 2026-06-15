using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Dominio.Strategies
{
    public interface IReglasNegocio
    {
        //regla 1 precio = margen sobre costo
        decimal CalcularPrecio(decimal costo);

        //regla 3 descuento segun cantidad de categorias del producto
        decimal CalcularDescuento(decimal precio, int cantidadCategorias);

        //regla 4 validar si hay stock suficiente para hacer una venta
        bool ValidarStock(int stockActual, int cantidadSolicitada);
    }
}
