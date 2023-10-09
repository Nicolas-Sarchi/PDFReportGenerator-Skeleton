using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categoria");
        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);
        builder.HasData(
            new Categoria { Id = 1, Nombre = "Tecnologia" },
            new Categoria { Id = 2, Nombre = "Supermercado" }
        );
    }
}
}