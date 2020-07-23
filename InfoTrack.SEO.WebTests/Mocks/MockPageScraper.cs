using InfoTrack.SEO.Scraper;
using System;
using System.Threading.Tasks;

namespace InfoTrack.SEO.WebTests.Mocks
{
    public class MockPageScraper : IPageScraper
    {
        public Task<string> GetPageSource(Uri pageUri)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
