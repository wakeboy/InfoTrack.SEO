using InfoTrack.SEO.Parser;
using InfoTrack.SEO.Parser.Helpers;
using InfoTrack.SEO.ParserTests.Mocks;
using NUnit.Framework;
using System.Runtime.InteropServices.ComTypes;

namespace InfoTrack.SEO.ParserTests
{
    public class GoogleSearchResultsParserTests
    {
        private IHtmlHelper htmlHelper;
        private ISearchResultsPageParser searchResultsPageParser;

        [SetUp]
        public void SetUp()
        {
            htmlHelper = new MockHtmlHelper();
            searchResultsPageParser = new GoogleSearchResultsParser(htmlHelper);
        }

        [Test]
        public void Parse_ShouldSuccessfullyParseHtml()
        {
            var result = searchResultsPageParser.Parse("<html></html>");

            Assert.AreEqual(5, result.SearchResults.Count);
        }
    }
}
