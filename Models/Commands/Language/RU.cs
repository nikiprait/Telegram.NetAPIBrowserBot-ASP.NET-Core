using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Tg_NetAPIBrowser.Resources.MSDN;

namespace Tg_NetAPIBrowser.Models.Commands.Language
{
    public class RU : Command
    {
        public override string Name => @"/RU";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Ищу информацию на русском языке!");
            Bot.Parser.Settings = new MSDNSettings
            { BaseUrl = "https://docs.microsoft.com/ru-ru/dotnet/api" };
            Bot.Parser.Worker(Bot.Search, message.Chat.Id.ToString());
        }
    }
}

