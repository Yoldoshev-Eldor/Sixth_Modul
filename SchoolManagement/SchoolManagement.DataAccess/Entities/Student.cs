namespace SchoolManagement.DataAccess.Entities;

public class Student
{
    public long ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public long TelegramID { get; set; }
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public ICollection<TeacherStudents> Teachers { get; set; } = new List<TeacherStudents>();
}
