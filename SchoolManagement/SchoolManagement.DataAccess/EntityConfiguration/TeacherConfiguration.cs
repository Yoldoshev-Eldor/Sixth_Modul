using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.DataAccess.Entities;

namespace SchoolManagement.DataAccess.EntityConfiguration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
         
            builder.ToTable("Teachers");

  
            builder.HasKey(t => t.ID);
           
                

            
            builder.Property(t => t.FirstName)
                   .IsRequired() 
                   .HasMaxLength(100);  

            builder.Property(t => t.LastName)
                   .IsRequired() 
                   .HasMaxLength(100);  

          
            builder.Property(t => t.PhoneNumber)
                   .IsRequired()  
                   .HasMaxLength(15);  

            builder.Property(t => t.Email)
                   .IsRequired()  
                   .HasMaxLength(200);  

        
            builder.Property(t => t.Salary)
                   .IsRequired(); 

           
            builder.Property(t => t.TelegramID)
                   .IsRequired(); 

           
            builder.HasMany(t => t.Students)
                   .WithOne(ts => ts.Teacher)  
                   .HasForeignKey(ts => ts.TeacherId);  
        }
    }
}
