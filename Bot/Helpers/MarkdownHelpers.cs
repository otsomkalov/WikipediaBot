using System.Text;
using WikipediaNet.Objects;

namespace Bot.Helpers
{
    public static class MarkdownHelpers
    {
        public static string GetMarkdown(Search search)
        {
            var markdownStringBuilder = new StringBuilder()
                .AppendLine($"<a href=\"{search.Url}\">{search.Title}</a>")
                .AppendLine(search.Snippet);

            return markdownStringBuilder.ToString();
        }
    }
}