using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Tg_NetAPIBrowser.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Hello, " + message.From.FirstName + "!");
        }
    }
}

