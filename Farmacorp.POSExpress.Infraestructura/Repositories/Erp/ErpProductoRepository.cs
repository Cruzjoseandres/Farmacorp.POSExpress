using Farmacorp.POSExpress.Dominio.Interfaces.Erp;
using Farmacorp.POSExpress.Dominio.Models.Erp;
using Farmacorp.POSExpress.Infraestructura.Data;
using Farmacorp.POSExpress.Infraestructura.Mappers.Erp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Farmacorp.POSExpress.Infraestructura.Repositories.Erp
{
    public class ErpProductoRepository : IErpProductosRepository
    {
        private readonly AppDbContext _context;

        public ErpProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ErpProductos> GetByIdAsync(object id)
        {
            var entity = await _context.ProductosERP.FindAsync(id);
            return entity == null ? null : ErpProductoMapper.ToDomain(entity);
        }

        public async Task<IEnumerable<ErpProductos>> GetAllAsync()
        {
            var entities = await _context.ProductosERP.ToListAsync();
            return entities.Select(e => ErpProductoMapper.ToDomain(e));
        }

        public async Task AddAsync(ErpProductos model)
        {
            var entity = ErpProductoMapper.ToEntity(model);
            await _context.ProductosERP.AddAsync(entity);
        }

        public void Delete(ErpProductos model)
        {
            var entity = ErpProductoMapper.ToEntity(model);
            _context.ProductosERP.Remove(entity);
        }


        public void Update(ErpProductos model)
        {
            var entity = ErpProductoMapper.ToEntity(model);
            _context.ProductosERP.Update(entity);

        }
    }
}
