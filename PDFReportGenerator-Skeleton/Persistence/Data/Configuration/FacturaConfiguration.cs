using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
{
    public void Configure(EntityTypeBuilder<Factura> builder)
    {
        builder.ToTable("factura");

        builder.Property(p => p.Total)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Fecha)
        .IsRequired()
        .HasColumnType("date");

        builder.HasOne(p => p.Cliente)
        .WithMany(p => p.Facturas)
        .HasForeignKey(p => p.IdClienteFk);

        builder.HasData(
            new Factura { Id = 1, IdClienteFk = 1, Fecha = DateOnly.FromDateTime(DateTime.Now), Total = 100 }
        );
    }
}
}