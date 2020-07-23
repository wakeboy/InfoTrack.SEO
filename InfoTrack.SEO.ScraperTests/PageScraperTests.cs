using InfoTrack.SEO.Scraper;
using InfoTrack.SEO.ScraperTests.Mocks;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrack.SEO.ScraperTests
{
    public class PageScraperTests
    {
        private const string testUrl = "https://www.test.com/search";
        private PageScraper pageScraper;

        [SetUp]
        public void Setup()
        {
            var mockHttpClientFactory = new MockHttpClientFactory(PageSource());
            pageScraper = new PageScraper(mockHttpClientFactory);
        }

        [Test]
        public async Task ShouldDownloadSearchResultsAsHtml()
        {
            var response = await pageScraper.GetPageSourceAsync(new Uri($"{testUrl}?q=test"));

            Assert.AreEqual(PageSource(), response);
        }

        private string PageSource()
        {
            return @"
<html>
    <head>
        <title>Test Title</title>
    </head>
    <body>
        <header>
            <h1>Header</h1>
        </header>
        <div class=""content"">
            <div class=""search-result"">
                <div class=""result"" aria-label=""Result 1"">Result 1</div>
                <div class=""result"">Result 2</div>
                <div class=""result"">Result 3</div>
                <div class=""result"">Result 4</div>
                <div class=""result"">Result 5</div>
            </div>
            <div class=""pagination"">
                <a class=""next-link"" href=""/serach?q=test"" aria-label=""Next Link"">Next Link</a>
            </div>
        </div>
        <footer>
            <div>Content</div>
        </footer>
    </body>
</html>";
        }
    }
}