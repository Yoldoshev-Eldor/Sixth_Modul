using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

namespace SchoolManagement.DataAccess.EntityConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.ID);
            builder.Property(s => s.ID).ValueGeneratedOnAdd();

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.TelegramID)
                .IsRequired();

            builder.HasMany(s => s.Teachers)
                .WithOne(ts => ts.Student)
                .HasForeignKey(ts => ts.StudentId);
        }
    }
}
