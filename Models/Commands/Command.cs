using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Tg_NetAPIBrowser.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract bool Contains(Message message);

        public abstract Task Execute(Message message, TelegramBotClient client);
    }
}
