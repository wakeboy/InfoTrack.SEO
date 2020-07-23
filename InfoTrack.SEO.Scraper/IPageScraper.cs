using System;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Scraper
{
    public interface IPageScraper
    {
        Task<string> GetPageSourceAsync(Uri pageUri);
    }
}
