using Bot.Resources;
using Microsoft.Extensions.Localization;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.Helpers
{
    public class InlineKeyboardHelpers
    {
        public static InlineKeyboardMarkup GetStartKeyboardMarkup(IStringLocalizer<Messages> localizer)
        {
            return new(new[]
            {
                InlineKeyboardButton.WithSwitchInlineQueryCurrentChat(localizer[ResourcesNames.SearchArticles]),
                InlineKeyboardButton.WithSwitchInlineQuery(localizer[ResourcesNames.ShareArticles])
            });
        }
    }
}
