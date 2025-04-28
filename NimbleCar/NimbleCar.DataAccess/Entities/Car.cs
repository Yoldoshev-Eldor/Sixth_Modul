namespace NimbleCar.DataAccess.Entities;

public class Car
{
    public long CarID { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public DateTime Year { get; set; }
    public DateTime PricePerDay { get; set; }
  
}
