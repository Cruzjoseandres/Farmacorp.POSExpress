using Farmacorp.POSExpress.Aplicacion.Interfaces.Erp;
using Farmacorp.POSExpress.Dominio.Interfaces;
using Farmacorp.POSExpress.Dominio.Models.Erp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacorp.POSExpress.Aplicacion.Services.Erp
{
    public class CodigoBarrasService : ICodigoBarrasService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CodigoBarrasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AsignarCodigoBarraAsync(int idProducto)
        {
            var producto = await _unitOfWork.ExpProductos.GetByIdAsync(idProducto);

            if (producto == null)
                throw new Exception("Producto no encontrado");

            var codigoBarra = new CodigoBarras
            {
                UniqueCodigo = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper(),
                Activo = true,
                IdProducto = idProducto,
            };

            await _unitOfWork.CodigoBarras.AddAsync(codigoBarra);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
