using InfoTrack.SEO.Parser.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.SEO.Parser.DependencyInjection
{
    public static class ParserServiceCollectionExtensions
    {
        public static void AddInfoTrackSEOParser(this IServiceCollection services)
        {
            services.AddSingleton<IHtmlHelper>();
            services.AddTransient<ISearchResultsPageParser, GoogleSearchResultsParser>();
        }
    }
}
