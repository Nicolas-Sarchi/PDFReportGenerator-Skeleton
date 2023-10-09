using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUnitOfWork
{
    ICategoria Categorias {get;}
    ICliente Clientes {get;}
    IFactura Facturas {get;}
    IDetalleFactura DetallesFactura {get;}
    IProducto Productos {get;}
    Task<int> SaveAsync();
}
}