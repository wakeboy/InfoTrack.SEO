using InfoTrack.SEO.Parser;
using InfoTrack.SEO.Parser.Models;
using InfoTrack.SEO.Scraper;
using InfoTrack.SEO.Web.Configuration;
using InfoTrack.SEO.Web.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Web.Analyzers
{
    public class GoogleSearchAnalyzer : ISearchResultsAnalyzer
    {
        private readonly IPageScraper scraper;
        private readonly ISearchResultsPageParser parser;
        private readonly GoogleSearchAnalyzerOptions settings;

        public GoogleSearchAnalyzer(IPageScraper scraper, ISearchResultsPageParser parser, IOptions<GoogleSearchAnalyzerOptions> settings)
        {
            this.scraper = scraper;
            this.parser = parser;
            this.settings = settings.Value;
        }
        public async Task<SEORankingModel> SearchResultRankingsAsync(string searchTerm, string matchUri)
        {
            var start = 0;
            var results = new List<SearchResult>();
            SearchResultsPage searchResultsPage = default;
            matchUri = RemoveProtocol(matchUri);

            while(results.Count < settings.CheckTopResults)
            {
                var uri = BuildUrl(searchTerm, start);
                string pageHtml = await this.scraper.GetPageSourceAsync(uri);
                searchResultsPage = parser.Parse(pageHtml);

                results.AddRange(searchResultsPage.SearchResults);
                start += 10;
            }

            var rankings = results.Select((r, i) => new { r.Uri, Ranking = i+1 })
                .Where(r => RemoveProtocol(r.Uri) == matchUri)
                .Select(r => r.Ranking)
                .ToArray();

            SEORankingModel response = new SEORankingModel
            {
                Rankings = string.Join(", ", rankings)
            };

            return response;
        }

        private string RemoveProtocol(string uri)
        {
            Regex removeProtocol = new Regex(@"^(https)?:\/\/|(http)?:\/\/|(www.)");
            return removeProtocol.Replace(uri, string.Empty);
        }

        private Uri BuildUrl(string searchTerm, int start)
        {
            return new Uri($"{settings.BaseSearchUri}/search?q={searchTerm}&start={start}");
        }
    }
}
