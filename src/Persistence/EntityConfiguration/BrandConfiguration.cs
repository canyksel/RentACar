using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.HasIndex(indexExpression: p =>p.Name, name:"UK_Brands_Name").IsUnique();
        //Markanın birden fazla modeli var.
        builder.HasMany(p => p.Models);

        Brand[] brandEntitySeeds = { 
            new(1, "BMW"), 
            new(2, "Mercedes")
        };
        builder.HasData(brandEntitySeeds);
    }
}
