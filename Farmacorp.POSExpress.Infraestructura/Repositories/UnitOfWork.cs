using Farmacorp.POSExpress.Dominio.Interfaces;
using Farmacorp.POSExpress.Dominio.Interfaces.Erp;
using Farmacorp.POSExpress.Dominio.Interfaces.Express;
using Farmacorp.POSExpress.Infraestructura.Data;
using Farmacorp.POSExpress.Infraestructura.Repositories.Erp;
using Farmacorp.POSExpress.Infraestructura.Repositories.Express;

namespace Farmacorp.POSExpress.Infraestructura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IExpProductosRepository ExpProductos { get; private set; }

        public ICategoriasRepository Categorias { get; private set; }

        public IProductosCategoriasRepository ProductosCategorias { get; private set; }

        public ITiposProductoRepository TiposProducto { get; private set; }

        public IVentaExpressRepository VentaExpress { get; private set; }

        public IErpProductosRepository ErpProductos  { get; private set; }

        public ICodigoBarrasRepository CodigoBarras  { get; private set; }

public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ExpProductos = new ExpProductosRepository(context);
            ErpProductos = new ErpProductoRepository(context);
            CodigoBarras = new CodigoBarrasRepository(context);
            TiposProducto = new TipoProductoRepository(context);
            Categorias = new CategoriasRepository(context);
            ProductosCategorias = new ProductosCategoriasRepository(context);
            VentaExpress = new VentaExpressRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
