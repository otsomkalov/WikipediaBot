using System.Threading.Tasks;
using Bot.Helpers;
using Bot.Resources;
using Microsoft.Extensions.Localization;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot.Services
{
    public class MessageService
    {
        private readonly ITelegramBotClient _bot;
        private readonly IStringLocalizer<Messages> _localizer;

        public MessageService(ITelegramBotClient bot, IStringLocalizer<Messages> localizer)
        {
            _bot = bot;
            _localizer = localizer;
        }

        public async Task HandleAsync(Message message)
        {
            if (message.Text.StartsWith("/start"))
            {
                await _bot.SendTextMessageAsync(
                    new(message.From.Id),
                    _localizer[ResourcesNames.Welcome],
                    replyMarkup: InlineKeyboardHelpers.GetStartKeyboardMarkup());
            }
        }
    }
}