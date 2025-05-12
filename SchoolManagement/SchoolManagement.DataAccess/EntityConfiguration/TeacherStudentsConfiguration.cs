using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

namespace SchoolManagement.DataAccess.EntityConfiguration
{
    public class TeacherStudentsConfiguration : IEntityTypeConfiguration<TeacherStudents>
    {
        public void Configure(EntityTypeBuilder<TeacherStudents> builder)
        {
         
            builder.ToTable("TeacherStudents");

          
            builder.HasKey(ts => new { ts.TeacherId, ts.StudentId });

            builder.HasOne(ts => ts.Teacher)
                   .WithMany(t => t.Students)
                   .HasForeignKey(ts => ts.TeacherId);

            builder.HasOne(ts => ts.Student)
                   .WithMany(s => s.Teachers)
                   .HasForeignKey(ts => ts.StudentId);
        }
    }
}
