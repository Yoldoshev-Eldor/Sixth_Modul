namespace NimbleCar.DataAccess.Entities;

public class Booking
{
    public long BookingID { get; set; }
    public long CustomerId  { get; set; }
    public  Customer Customer { get; set; }
    public long CarID { get; set; }
    public Car Car { get; set; }
    public DateTime StartDate  { get; set; }
    public DateTime EndDate  { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public double TotalCost { get; set; }
}
