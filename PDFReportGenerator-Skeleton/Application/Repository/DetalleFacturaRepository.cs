using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
     public class DetalleFacturaRepository : GenericRepository<DetalleFactura>, IDetalleFactura
    {
        private readonly ProjectDbContext _context;
        public DetalleFacturaRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<DetalleFactura>> GetAllAsync()
        {
            return await _context.DetalleFacturas 
                .Include(p => p.Producto)
                .ToListAsync();
        }
    }
}