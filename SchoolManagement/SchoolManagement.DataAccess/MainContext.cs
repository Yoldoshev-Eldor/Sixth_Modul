using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Entities;
using SchoolManagement.DataAccess.EntityConfiguration;

namespace SchoolManagement.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Student> Students{ get; set; }
    public DbSet<Subject> Subjects{ get; set; }
    public DbSet<Teacher> Teachers{ get; set; }
    public DbSet<TeacherStudents> TeacherStudents{ get; set; }
   


    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GradeConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherStudentsConfiguration());

    }
}
