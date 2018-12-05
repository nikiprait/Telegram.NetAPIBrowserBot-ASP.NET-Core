using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Tg_NetAPIBrowser.Models.Commands;
using Tg_NetAPIBrowser.Models.Commands.Language;
using Tg_NetAPIBrowser.Resources;
using Tg_NetAPIBrowser.Resources.MSDN;

namespace Tg_NetAPIBrowser.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        internal static ParserWorker<string[]> Parser { get; set; }

        public static string Search = "";

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>
            {
                new StartCommand(),
                new RU(),
                new ENG(),
                new PL(),
                new DE(),
                new DefaultCommand()
            };

            Parser = new ParserWorker<string[]>(new MSDNParser());

            Parser.OnNewData += Parser_OnNewData;

            botClient = new TelegramBotClient(AppSettings.Key);
            string hook = string.Format(AppSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }

        private static async void Parser_OnNewData(object arg1, string[] arg2, string arg3)
        {
            try
            {
                await botClient.SendTextMessageAsync(arg3, arg2[0]);
            }
            catch
            {
                await botClient.SendTextMessageAsync(arg3, "Error, this is not look like namespace or class or method, try again.");
            }
        }
    }
}
