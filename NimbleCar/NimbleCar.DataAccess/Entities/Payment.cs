using NimbleCar.DataAccess.Enums;

namespace NimbleCar.DataAccess.Entities;

public class Payment
{
    public long PaymentID { get; set; }
    public long BookingId { get; set; }
    public Booking Booking { get; set; }
    public double Amount { get; set; }
    public PaymentStatus  Status { get; set; }
}
