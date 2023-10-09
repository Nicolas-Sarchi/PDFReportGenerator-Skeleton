using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Factura : BaseEntity
{
    public int IdClienteFk { get; set; }
    public Cliente Cliente {get;set;}
    public DateOnly Fecha {get;set;} 
    public double Total {get;set;}
    public ICollection<DetalleFactura> DetallesFactura {get;set;}
}
}