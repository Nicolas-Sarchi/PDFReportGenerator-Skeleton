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
     public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
     private readonly ProjectDbContext _context;
        public ClienteRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Cliente>> GetAllAsync()
{
 return await _context.Clientes.ToListAsync();
}  
}
}