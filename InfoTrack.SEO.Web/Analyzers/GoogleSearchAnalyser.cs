using InfoTrack.SEO.Parser;
using InfoTrack.SEO.Parser.Models;
using InfoTrack.SEO.Scraper;
using InfoTrack.SEO.Web.Configuration;
using InfoTrack.SEO.Web.Models;
using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Web.Analyzers
{
    public class GoogleSearchAnalyser : ISearchResultsAnalyser
    {
        private readonly IPageScraper scraper;
        private readonly ISearchResultsPageParser parser;
        private readonly GoogleSearchAnalyzerOptions settings;

        public GoogleSearchAnalyser(IPageScraper scraper, ISearchResultsPageParser parser, IOptions<GoogleSearchAnalyzerOptions> settings)
        {
            this.scraper = scraper;
            this.parser = parser;
            this.settings = settings.Value;
        }
        public async Task<SEORankingModel> SearchResultRankings(string searchTerm)
        {
            var start = 0;
            var results = new List<SearchResult>();
            SearchResultsPage searchResultsPage = default;
            

            while(results.Count < settings.CheckTopResults)
            {
                var uri = BuildUrl(searchTerm, start);
                string pageHtml = await this.scraper.GetPageSource(uri);
                searchResultsPage = parser.Parse(pageHtml);

                results.AddRange(searchResultsPage.SearchResults);
                start += 10;
            }

            var rankings = results.Select((r, i) => new { r.Uri, Ranking = i+1 })
                .Where(r => Array.Exists(settings.MatchUris.ToArray(), uri => uri == r.Uri)) 
                .Select(r => r.Ranking)
                .ToArray();


            SEORankingModel response = new SEORankingModel
            {
                Rankings = string.Join(", ", rankings)
            };

            return response;
        }

        private Uri BuildUrl(string searchTerm, int start)
        {
            return new Uri($"{settings.BaseSearchUri}/search?q={searchTerm}&start={start}");

            //if (string.IsNullOrEmpty(nextPageUri))
            //{
            //    return new Uri($"{settings.BaseSearchUri}/search?q={searchTerm}");
            //}
            //else
            //    return new Uri($"{settings.BaseSearchUri}/{nextPageUri}");
        }
    }
}
