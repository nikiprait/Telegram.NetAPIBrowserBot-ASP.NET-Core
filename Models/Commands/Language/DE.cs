using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Tg_NetAPIBrowser.Resources;
using Tg_NetAPIBrowser.Resources.MSDN;

namespace Tg_NetAPIBrowser.Models.Commands.Language
{
    public class DE : Command
    {
        public override string Name => @"/DE";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Ich suche Informationen auf Deutsch!");
            Bot.Parser.Settings = new MSDNSettings
            { BaseUrl = "https://docs.microsoft.com/de-de/dotnet/api" };
            Bot.Parser.Worker(Bot.Search, message.Chat.Id.ToString());
        }
    }
}

