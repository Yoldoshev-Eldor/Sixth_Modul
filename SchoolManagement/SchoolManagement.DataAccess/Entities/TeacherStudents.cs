namespace SchoolManagement.DataAccess.Entities;

public class TeacherStudents
{
    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    public long StudentId { get; set; }
    public Student Student { get; set; }

}
