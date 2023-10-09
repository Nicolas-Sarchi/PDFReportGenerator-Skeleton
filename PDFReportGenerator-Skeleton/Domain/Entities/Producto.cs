using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Producto : BaseEntity
{
    public int IdCategoriaFk { get; set; }
    public Categoria Categoria { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public ICollection<DetalleFactura> DetallesFactura {get;set;}

}
}