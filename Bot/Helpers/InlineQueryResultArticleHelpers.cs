using System.Text.RegularExpressions;
using Telegram.Bot.Types.InlineQueryResults;
using WikipediaNet.Objects;

namespace Bot.Helpers
{
    public static class InlineQueryResultArticleHelpers
    {
        public static InlineQueryResultArticle GetInlineQueryResultArticleForArticle(Search article)
        {
            article.Snippet = Regex.Replace(article.Snippet, "<.*?>", string.Empty);

            return new(article.Title, article.Title, InputTextMessageContentHelpers.GetInputTextMessageContent(article))
            {
                Description = article.Snippet  
            };
        }
    }
}