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

        Model[] modelEntitySeeds = {
            new(1, 1, "Series 4", 1500, ""),
            new(2,1,"Series 3",1250,""),
            new(3,2,"A180",1100,"")
        };
        builder.HasData(modelEntitySeeds);
    }
}
