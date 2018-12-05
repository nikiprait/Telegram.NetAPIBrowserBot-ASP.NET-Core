using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Tg_NetAPIBrowser.Models.Commands
{
    public class DefaultCommand : Command
    {
        public override string Name => "";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(message.Text);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var language = new ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                                                new[]
                                                {
                                                    new KeyboardButton("RU"),
                                                    new KeyboardButton("ENG"),
                                                    new KeyboardButton("PL"),
                                                    new KeyboardButton("DE")
                                                },
                                            },
                ResizeKeyboard = true
            };

            await botClient.SendTextMessageAsync(message.Chat.Id, "Hi, " + message.From.FirstName + "!\nYou search: " + message.Text, ParseMode.Default, false, false, 0, language);
            Bot.Search = message.Text;
        }
    }
}

