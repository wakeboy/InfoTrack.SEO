using System;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Scraper
{
    public interface IPageScraper
    {
        Task<string> GetPageSource(Uri pageUri);
    }
}
