using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.BrandId).HasColumnName("BrandId");
            builder.Property(c => c.ModelId).HasColumnName("ModelId");
            builder.Property(c => c.CarState).HasColumnName("CarState");
            builder.Property(c => c.Kilometer).HasColumnName("Kilometer");
            builder.Property(c => c.ModelYear).HasColumnName("ModelYear");
            builder.Property(c => c.Plate).HasColumnName("Plate");
            builder.HasOne(c => c.Brand);
            builder.HasOne(c=> c.Model);

            Car[] carEntitySeeds = {
                new(1,1,1,CarState.Avaliable,4000,2021,"34TEST34"),
                new(2,1,1,CarState.Maintenance,9000,2019,"34TEST35"),
                new(3,2,2,CarState.Rented,4500,2020,"34TEST35")

            };
            builder.HasData(carEntitySeeds);
        }
    }
}
