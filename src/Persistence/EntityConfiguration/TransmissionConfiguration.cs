using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;

public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
    public void Configure(EntityTypeBuilder<Transmission> builder)
    {
        builder.ToTable("Transmissions").HasKey("Id");
        builder.Property(t => t.Id).HasColumnName("Id");
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.HasMany(t => t.Models);


        Transmission[] transmissionEntitySeeds = {
            new(id:1, name: "Manuel"),
            new(id:2, name:"Automatic"),
            new(id:3, name:"Semi-automatic")
        };
        builder.HasData(transmissionEntitySeeds);
    }
}
