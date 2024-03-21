using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(m => m.Id);
        builder.Property(m => m.Id).HasColumnName("Id");
        builder.Property(m => m.BrandId).HasColumnName("BrandId");
        builder.Property(m => m.Name).HasColumnName("Name");
        builder.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
        builder.Property(m => m.ImageUrl).HasColumnName("ImageUrl");
        //Modelin bir adet markası var.
        builder.HasOne(m => m.Brand);
        builder.HasMany(m => m.Cars);

        Model[] modelEntitySeeds = {
            new(id: 1, brandId: 1, name: "Series 4", dailyPrice: 1500, imageUrl: ""),
            new(id: 2,brandId: 1,name: "Series 3",dailyPrice: 1250,imageUrl: ""),
            new(id: 3,brandId: 2,name: "A180",dailyPrice: 1100,imageUrl: "")
        };
        builder.HasData(modelEntitySeeds);
    }
}
