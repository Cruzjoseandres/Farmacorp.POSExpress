using Farmacorp.POSExpress.Dominio.Models.Express;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farmacorp.POSExpress.Aplicacion.Interfaces.Erp
{
    public interface IErpProductoService
    {
        Task RegistrarProductoErpAsync(int idProducto, decimal costo, int stock);

    }
}
