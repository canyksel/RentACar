using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ColorId).HasColumnName("ColorId");
            builder.Property(c => c.ModelId).HasColumnName("ModelId");
            builder.Property(c => c.CarState).HasColumnName("CarState");
            builder.Property(c => c.Kilometer).HasColumnName("Kilometer");
            builder.Property(c => c.ModelYear).HasColumnName("ModelYear");
            builder.Property(c => c.Plate).HasColumnName("Plate");
            builder.HasOne(c => c.Color);
            builder.HasOne(c => c.Model);

            Car[] carEntitySeeds =
            {
            new(
                id: 1,
                colorId: 1,
                modelId: 1,
                CarState.Available,
                kilometer: 1000,
                modelYear: 2018,
                plate: "34ABC34"
            ),
            new(
                id: 2,
                colorId: 2,
                modelId: 2,
                CarState.Rented,
                kilometer: 1000,
                modelYear: 2018,
                plate: "35ABC35"
            )
        };
            builder.HasData(carEntitySeeds);
        }
    }
}
