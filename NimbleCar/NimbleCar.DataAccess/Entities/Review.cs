namespace NimbleCar.DataAccess.Entities;

public class Review
{
    public long ReviewID { get; set; }
    public long CustomerID { get; set; }
    public Customer Customer { get; set; }
    public long CarID { get; set; }
    public Car Car { get; set; }
    public double Rating { get; set; }
    public List<string> Comments { get; set; }
}
