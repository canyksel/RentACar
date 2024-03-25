using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfiguration;

public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
{
    public void Configure(EntityTypeBuilder<Fuel> builder)
    {
        builder.ToTable("Fuels").HasKey(f => f.Id);
        builder.Property(f => f.Id).HasColumnName("Id");
        builder.Property(f => f.Name).HasColumnName("Name");
        builder.HasIndex(indexExpression: f => f.Name, name: "UK_Fuels_Name").IsUnique();
        builder.HasMany(f => f.Models);

        Fuel[] fuelEntitySeeds = {
            new(1,"Diesel"),
            new(2,"Gasoline"),
            new(3,"Electric")
        };
        builder.HasData(fuelEntitySeeds);
    }
}
