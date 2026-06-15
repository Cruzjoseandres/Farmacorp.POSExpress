using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Aplicacion.Interfaces.Erp
{
    public interface ICodigoBarrasService
    {
        Task AsignarCodigoBarraAsync(int idProducto);
    }
}
