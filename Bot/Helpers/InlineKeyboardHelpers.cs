using Telegram.Bot.Types.ReplyMarkups;

namespace Bot.Helpers
{
    public class InlineKeyboardHelpers
    {
        public static InlineKeyboardMarkup GetStartKeyboardMarkup()
        {
            return new(new[]
            {
                InlineKeyboardButton.WithSwitchInlineQueryCurrentChat("🔍 Search articles"),
                InlineKeyboardButton.WithSwitchInlineQuery("🔗 Find and share articles")
            });
        }
    }
}
