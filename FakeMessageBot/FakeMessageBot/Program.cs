using FakeMessageBot.Services;
using FakeMessageBot;
using Microsoft.Extensions.Configuration;
using System.IO;
using Telegram.Bot;

internal class Program
{
    static async Task Main(string[] args)
    {
        
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())  
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)  
            .Build();

        var botToken = config["TelegramBot:Token"];
        var googleApiKey = config["GoogleApi:ApiKey"];

        var botClient = new TelegramBotClient(botToken);
        var factCheckService = new GoogleFactCheckService(googleApiKey);
        var handler = new BotHandleMessage(botClient, factCheckService);

        botClient.StartReceiving(
            async (bot, update, cancellationToken) => await handler.HandleAsync(update),
            (bot, exception, cancellationToken) =>
            {
                Console.WriteLine($"Xatolik: {exception.Message}");
                return Task.CompletedTask;
            });

        Console.WriteLine("Bot ishga tushdi...");
        await Task.Delay(-1);
    }
}
