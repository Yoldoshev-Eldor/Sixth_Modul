using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NimbleCar.DataAccess.Entities.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {

        builder.ToTable("Reviews");


        builder.HasKey(r => r.ReviewID);


        builder.HasOne(r => r.Customer)
            .WithMany()
            .HasForeignKey(r => r.CustomerID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Car)
            .WithMany()
            .HasForeignKey(r => r.CarID)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Property(r => r.Rating)
            .IsRequired()
            .HasColumnType("decimal(3, 2)")
            .HasDefaultValue(0);

        builder.Property(r => r.Comments)
            .IsRequired()
            .HasMaxLength(500);


        builder.HasIndex(r => new { r.CustomerID, r.CarID });
    }
}