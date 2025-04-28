namespace StrategyAndFactory;

public class Sms : IMessage
{
    public void ChoseOption(string option)
    {
        Console.WriteLine("Sms");
    }
}
