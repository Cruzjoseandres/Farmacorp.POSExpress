using Farmacorp.POSExpress.Dominio.Interfaces.Erp;
using Farmacorp.POSExpress.Dominio.Interfaces.Express;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Dominio.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //express
        IExpProductosRepository ExpProductos { get; }
        ICategoriasRepository Categorias { get; }
        IProductosCategoriasRepository ProductosCategorias { get; }
        ITiposProductoRepository TiposProducto { get; }
        IVentaExpressRepository VentaExpress { get; }

        //erp
        IErpProductosRepository ErpProductos { get; }
        ICodigoBarrasRepository CodigoBarras { get; }

        Task<int> SaveChangesAsync();

    }
}
