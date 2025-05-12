namespace SchoolManagement.DataAccess.Entities;

public class Subject
{
    public long Id { get; set; }

    public string Name { get; set; }

    // Talabalar bilan bog‘lanish
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
