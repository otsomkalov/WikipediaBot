using System.Linq;
using System.Threading.Tasks;
using Bot.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using WikipediaNet;

namespace Bot.Services
{
    public class InlineQueryService
    {
        private readonly Wikipedia _wikipedia;
        private readonly ITelegramBotClient _bot;

        public InlineQueryService(Wikipedia wikipedia, ITelegramBotClient bot)
        {
            _wikipedia = wikipedia;
            _bot = bot;
        }

        public async Task HandleAsync(InlineQuery inlineQuery)
        {
            if (string.IsNullOrEmpty(inlineQuery.Query))
            {
                return;
            }
            
            var articles = _wikipedia.Search(inlineQuery.Query);

            var response =
                articles.Search.Select(InlineQueryResultArticleHelpers.GetInlineQueryResultArticleForArticle);

            await _bot.AnswerInlineQueryAsync(inlineQuery.Id, response);
        }
    }
}