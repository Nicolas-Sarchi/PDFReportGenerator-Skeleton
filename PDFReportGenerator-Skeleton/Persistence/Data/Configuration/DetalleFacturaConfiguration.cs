using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
     public class DetalleFacturaConfiguration : IEntityTypeConfiguration<DetalleFactura>
  {
     public void Configure(EntityTypeBuilder<DetalleFactura> builder)
    {
        builder.ToTable("detalle_factura");

        builder.Property(p => p.Cantidad)
        .IsRequired()
        .HasColumnType("int");

         builder.Property(p => p.Precio)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Producto)
        .WithMany(p => p.DetallesFactura)
        .HasForeignKey(p => p.IdProductoFk);

        builder.HasOne(p => p.Factura)
        .WithMany(p => p.DetallesFactura)
        .HasForeignKey(p => p.IdFacturaFk);

        builder.HasData(
          new DetalleFactura { Id = 1, IdFacturaFk = 1, IdProductoFk = 1, Cantidad = 1, Precio = 100 }
        );
  }
  }
}