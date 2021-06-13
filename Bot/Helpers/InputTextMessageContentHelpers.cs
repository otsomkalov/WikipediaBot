using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using WikipediaNet.Objects;

namespace Bot.Helpers
{
    public static class InputTextMessageContentHelpers
    {
        public static InputTextMessageContent GetInputTextMessageContent(Search search)
        {
            return new(MarkdownHelpers.GetMarkdown(search))
            {
                ParseMode = ParseMode.Html
            };
        }
    }
}