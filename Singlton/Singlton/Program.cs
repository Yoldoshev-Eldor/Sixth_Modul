namespace Singlton;

internal class Program
{
    static void Main(string[] args)
    {
        var option = "uzum";

        var strategyType = PaymentFactory.GetObject(option);

        var notifyStrategy = new PaymentStrategy(strategyType);
        notifyStrategy.Payment($"Payment option {option}");
    }
}
