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
        builder.Property(m => m.FuelId).HasColumnName("FuelId");
        builder.Property(m => m.TransmissionId).HasColumnName("TransmissionId");
        builder.Property(m => m.Name).HasColumnName("Name");
        builder.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
        builder.Property(m => m.ImageUrl).HasColumnName("ImageUrl");
        //Modelin bir adet markası var.
        builder.HasOne(m => m.Brand);
        //Modelin bir adet yakıt türü var.
        builder.HasOne(m => m.Fuel);
        //Modelin bir adet vites türü var.
        builder.HasOne(m => m.Transmission);
        //Modelin birden fazla arabası var.
        builder.HasMany(m => m.Cars);

        Model[] modelEntitySeeds = {
            new(id: 1, brandId: 1, fuelId:1, transmissionId:1, name: "Series 4", dailyPrice: 1500, imageUrl: ""),
            new(id: 2,brandId: 1,fuelId: 2, transmissionId:1, name: "Series 3",dailyPrice: 1250,imageUrl: ""),
            new(id: 3,brandId: 2,fuelId: 3, transmissionId:2, name: "A180",dailyPrice: 1100,imageUrl: "")
        };
        builder.HasData(modelEntitySeeds);
    }
}
