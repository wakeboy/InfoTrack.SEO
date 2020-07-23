using InfoTrack.SEO.Parser;
using InfoTrack.SEO.Parser.Models;
using System.Collections.Generic;

namespace InfoTrack.SEO.WebTests.Mocks
{
    public class MockGoogleSearchResultsParser : ISearchResultsPageParser
    {
        public SearchResultsPage Parse(string pageHtml)
        {
            return new SearchResultsPage
            {
                SearchResults = new List<SearchResult>
                 {
                    new GoogleSearchResult(@"<div class=""result"" aria-label=""Result 1"">test.com</div>"),
                    new GoogleSearchResult(@"<div class=""result"">Result 2</div>"),
                    new GoogleSearchResult(@"<div class=""result"">www.test.com</div>"),
                    new GoogleSearchResult(@"<div class=""result"">Result 4</div>"),
                    new GoogleSearchResult(@"<div class=""result"">http://www.test.com</div>")
                 }    
            };
        }
    }
}
