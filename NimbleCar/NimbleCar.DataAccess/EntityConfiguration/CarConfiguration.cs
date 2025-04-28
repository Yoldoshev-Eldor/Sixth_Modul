using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NimbleCar.DataAccess.Entities;

namespace NimbleCar.DataAccess.EntityConfiguration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Car");

        builder.HasKey(c => c.CarID);

        builder.Property(c => c.Model)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(c => c.Brand)
            .IsRequired(true)
            .HasMaxLength(50);

        builder.Property(c => c.Year)
            .IsRequired(true);

        builder.Property(c => c.PricePerDay)
            .IsRequired(true);

        
    }
}
