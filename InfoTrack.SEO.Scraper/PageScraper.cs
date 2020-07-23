using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Scraper
{
    public class PageScraper : IPageScraper
    {
        private readonly IHttpClientFactory httpClientFactory;

        public PageScraper(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetPageSourceAsync(Uri pageUrl)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync(pageUrl);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
