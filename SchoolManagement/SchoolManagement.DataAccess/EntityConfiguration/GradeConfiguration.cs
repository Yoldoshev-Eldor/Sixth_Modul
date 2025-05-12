using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

namespace SchoolManagement.DataAccess.EntityConfiguration;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {

        builder.ToTable("Grades");

        builder.HasKey(g => g.Id);

       
        builder.Property(g => g.DateGiven)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()"); 

      
        builder.HasOne(g => g.Student)
               .WithMany(s => s.Grades)
               .HasForeignKey(g => g.StudentId)
               .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(g => g.Subject)
               .WithMany(s => s.Grades)
               .HasForeignKey(g => g.SubjectId)
               .OnDelete(DeleteBehavior.Cascade); 
    }
}
