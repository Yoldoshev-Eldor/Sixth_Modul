using FakeMessageBot.Services;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace FakeMessageBot;

public class BotHandleMessage
{
    private readonly ITelegramBotClient _botClient;
    private readonly GoogleFactCheckService _factCheckService;

    public BotHandleMessage(ITelegramBotClient botClient, GoogleFactCheckService factCheckService)
    {
        _botClient = botClient;
        _factCheckService = factCheckService;
    }

    public async Task HandleAsync(Update update)
    {
        if (update.Message == null || string.IsNullOrEmpty(update.Message.Text))
            return;

        var chatId = update.Message.Chat.Id;
        var messageText = update.Message.Text;

        // 1. Foydalanuvchining xabarini Google Fact Check API orqali tekshirish
        var result = await _factCheckService.CheckMessageAsync(messageText);

        string replyMessage;

        if (result != null && result.Any())
        {
            replyMessage = "⚠️ Shubhali ma'lumotlar topildi:\n\n";
            foreach (var claim in result)
            {
                replyMessage += $"• {claim.Title}\n";
                replyMessage += $"Manba: {claim.Url}\n\n";
            }
        }
        else
        {
            replyMessage = "✅ Hech qanday shubhali ma'lumot topilmadi. Xabar ishonchli ko'rinadi.";
        }

        // 2. Foydalanuvchiga javob qaytarish
        await _botClient.SendMessage(chatId, replyMessage);
    }
}