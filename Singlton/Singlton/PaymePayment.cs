namespace Singlton;

public class PaymePayment : IPaymentSysteam
{
    public void ChoosePayment(string option)
    {
        Console.WriteLine($"{option} tanlandi ");
    }
}
