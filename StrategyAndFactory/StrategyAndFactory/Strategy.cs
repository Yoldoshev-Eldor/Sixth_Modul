namespace StrategyAndFactory;

public class Strategy
{
    private readonly IMessage _option;
    public Strategy(IMessage option)
    {
        _option = option;
    }

    public void Message(string message)
    {
        _option.ChoseOption(message);
    }
}
