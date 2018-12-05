using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Tg_NetAPIBrowser.Models;

namespace Tg_NetAPIBrowser.Controllers
{
    [Route("api/message/update")]
    public class MessageController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Method GET unuvalable";
        }

        // POST api/values
        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null)
                return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            return Ok();
        }
    }
}