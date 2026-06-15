using Farmacorp.POSExpress.Dominio.Interfaces.Erp;
using Farmacorp.POSExpress.Dominio.Models.Erp;
using Farmacorp.POSExpress.Infraestructura.Data;
using Farmacorp.POSExpress.Infraestructura.Mappers.Erp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Text;

namespace Farmacorp.POSExpress.Infraestructura.Repositories.Erp
{
    public class CodigoBarrasRepository : ICodigoBarrasRepository
    {
        private readonly AppDbContext _context;

        public CodigoBarrasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CodigoBarras model)
        {
            var entity = CodigoBarrasMapper.ToEntity(model);
            await _context.CodigosBarras.AddAsync(entity);
        }

        public void Delete(CodigoBarras model)
        {
            var entity = CodigoBarrasMapper.ToEntity(model);
            _context.CodigosBarras.Remove(entity);
        }

        public async Task<IEnumerable<CodigoBarras>> GetAllAsync()
        {
            var entities = await _context.CodigosBarras.ToListAsync();
            return entities.Select(e => CodigoBarrasMapper.ToDomain(e));
        }

        public async Task<CodigoBarras> GetByIdAsync(object id)
        {
            var entity = await _context.CodigosBarras.FindAsync(id);
            return entity == null ? null : CodigoBarrasMapper.ToDomain(entity);
        }

        public void Update(CodigoBarras model)
        {
            var entity = CodigoBarrasMapper.ToEntity(model);
            _context.CodigosBarras.Update(entity);
        }
    }
}
