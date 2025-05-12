namespace SchoolManagement.DataAccess.Entities;

public class Teacher
{
    public long ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public long TelegramID { get; set; }
    public ICollection<TeacherStudents> Students { get; set; } = new List<TeacherStudents>();
}
