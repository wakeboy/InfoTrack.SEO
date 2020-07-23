using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.SEO.Scraper.DependencyInjection
{
    public static class ScraperServiceCollectionExtensions
    {
        public static void AddInfoTrackSEOScraper(this IServiceCollection services)
        {
            services.AddTransient<IPageScraper>();
        }
    }
}
