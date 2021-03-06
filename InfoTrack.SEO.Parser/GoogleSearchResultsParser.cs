﻿using InfoTrack.SEO.Parser.Helpers;
using InfoTrack.SEO.Parser.Models;
using System.Linq;

namespace InfoTrack.SEO.Parser
{
    public class GoogleSearchResultsParser : ISearchResultsPageParser
    {
        private const string SearchResultClass = "BNeawe UPmit AP7Wnd";

        private readonly IHtmlHelper htmlHelper;

        public GoogleSearchResultsParser(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public SearchResultsPage Parse(string pageHtml)
        {
            var searchResults = htmlHelper.FindElementsByCssClass(pageHtml, "div", SearchResultClass);

            return new SearchResultsPage
            {
                SearchResults = searchResults.Select(r => new GoogleSearchResult(r)).ToList<SearchResult>()
            };
        }
    }
}
