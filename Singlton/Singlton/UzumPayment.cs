namespace Singlton;

public class UzumPayment : IPaymentSysteam
{
    public void ChoosePayment(string option)
    {
        Console.WriteLine($"{option} tanlandi ");
    }
}
