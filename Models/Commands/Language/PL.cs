using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Tg_NetAPIBrowser.Resources;
using Tg_NetAPIBrowser.Resources.MSDN;

namespace Tg_NetAPIBrowser.Models.Commands.Language
{
    public class PL : Command
    {
        public override string Name => @"/PL";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Szukam informacje w języku polskim!");
            Bot.Parser.Settings = new MSDNSettings
            { BaseUrl = "https://docs.microsoft.com/pl-pl/dotnet/api" };
            Bot.Parser.Worker(Bot.Search, message.Chat.Id.ToString());
        }
    }
}

