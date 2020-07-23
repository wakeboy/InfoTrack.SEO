using InfoTrack.SEO.Parser.Models;

namespace InfoTrack.SEO.Parser
{
    public interface ISearchResultsPageParser
    {
        SearchResultsPage Parse(string pageHtml);
    }
}
