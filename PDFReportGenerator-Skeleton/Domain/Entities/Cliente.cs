using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono {get; set;}
    public string Email {get; set;}
    public ICollection<Factura> Facturas {get;set;}
}
}