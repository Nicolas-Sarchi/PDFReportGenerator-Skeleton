using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
     public class ProductoRepository : GenericRepository<Producto>, IProducto
    {
        private readonly ProjectDbContext _context;
        public ProductoRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos 
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosPorCategoria(int categoriaId)
        {
            var productos = await _context.Productos
                .Where(p => p.IdCategoriaFk == categoriaId)
                .ToListAsync();

            return productos;
        }
    }
}