using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

namespace SchoolManagement.DataAccess.EntityConfiguration;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
       
        builder.ToTable("Subjects");

       
        builder.HasKey(s => s.Id);

     


      
        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(100);

      
        builder.HasMany(s => s.Grades)
               .WithOne(g => g.Subject)
               .HasForeignKey(g => g.SubjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
