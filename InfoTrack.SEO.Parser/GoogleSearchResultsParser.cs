using InfoTrack.SEO.Parser.Helpers;
using InfoTrack.SEO.Parser.Models;
using System.Linq;

namespace InfoTrack.SEO.Parser
{
    public class GoogleSearchResultsParser : ISearchResultsPageParser
    {
        private const string SEARCH_RESULT_CLASS = "BNeawe UPmit AP7Wnd";
        private const string NEXT_LINK_CLASS = "nBDE1b G5eFlf";

        private readonly IHtmlHelper htmlHelper;

        public GoogleSearchResultsParser(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public SearchResultsPage Parse(string pageHtml)
        {
            var searchResults = htmlHelper.FindElementsByCssClass(pageHtml, "div", SEARCH_RESULT_CLASS);
            var nextLink = htmlHelper.FindElementByCssClass(pageHtml, "a", NEXT_LINK_CLASS);

            return new SearchResultsPage
            {
                SearchResults = searchResults.Select(r => new GoogleSearchResult(r)).ToList<SearchResult>(),
                NextPageUri = htmlHelper.GetHtmlAttributeValue(nextLink, "href")
            };
        }
    }
}
