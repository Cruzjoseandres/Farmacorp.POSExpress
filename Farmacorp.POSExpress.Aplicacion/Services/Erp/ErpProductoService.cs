using Farmacorp.POSExpress.Aplicacion.Interfaces.Erp;
using Farmacorp.POSExpress.Dominio.Interfaces;
using Farmacorp.POSExpress.Dominio.Models.Erp;
using Farmacorp.POSExpress.Dominio.Models.Express;
using Farmacorp.POSExpress.Dominio.Strategies;
using System.Numerics;


namespace Farmacorp.POSExpress.Aplicacion.Services.Erp
{
    public class ErpProductoService : IErpProductoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReglasNegocio _reglasNegocio;

        public ErpProductoService(IUnitOfWork unitOfWork, IReglasNegocio reglasNegocio)
        {
            _unitOfWork = unitOfWork;
            _reglasNegocio = reglasNegocio;
        }
        public async Task RegistrarProductoErpAsync(int idProducto, decimal costo)
        {
            var producto = await _unitOfWork.ExpProductos.GetByIdAsync(idProducto);
            if (producto == null)
                throw new Exception("Producto no encontrado");

            var productoErp = await _unitOfWork.ErpProductos.GetByIdAsync(idProducto);
            if (productoErp != null)
                throw new Exception("Producto ERP ya registrado");


            var precio = _reglasNegocio.CalcularPrecio(costo);

            producto.Precio = precio;
            _unitOfWork.ExpProductos.Update(producto);

            var erpProducto = new ErpProductos
            {
                IdProducto = idProducto,
                Costo = costo,
                UniqueCodigo = Guid.NewGuid().ToString("N").Substring(0,10).ToUpper(),
                FechaRegistro = DateTime.UtcNow,
                Stock = 0
            };

            await _unitOfWork.ErpProductos.AddAsync(erpProducto);
            await _unitOfWork.SaveChangesAsync();
        }


    }
}
