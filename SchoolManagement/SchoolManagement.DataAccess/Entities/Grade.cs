namespace SchoolManagement.DataAccess.Entities;

public class Grade
{
    public long Id { get; set; }

    public long StudentId { get; set; }
    public Student Student { get; set; }


    public long SubjectId { get; set; }
    public Subject Subject { get; set; }

    public decimal GradeValue { get; set; }

    public DateTime DateGiven { get; set; }
}
