using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository
{
    public class FacturaRepository : GenericRepository<Factura>, IFactura
    {
        private readonly ProjectDbContext _context;
        public FacturaRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _context.Facturas
                .Include(p => p.DetallesFactura)
                .ThenInclude(p => p.Producto)
                .ThenInclude(p => p.Categoria)
                .Include(p => p.Cliente)
                .ToListAsync();
        }
        public override async Task<Factura> GetByIdAsync(int id)
        {
            return await _context.Set<Factura>().Include(p => p.DetallesFactura)
                .ThenInclude(p => p.Producto)
                .ThenInclude(p => p.Categoria)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}