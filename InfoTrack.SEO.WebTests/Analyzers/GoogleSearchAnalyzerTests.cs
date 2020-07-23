using InfoTrack.SEO.Parser;
using InfoTrack.SEO.Scraper;
using InfoTrack.SEO.Web.Analyzers;
using InfoTrack.SEO.Web.Configuration;
using InfoTrack.SEO.WebTests.Mocks;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.SEO.WebTests.Analyzers
{
    public class GoogleSearchAnalyzerTests
    {
        private ISearchResultsAnalyzer searchResultsAnalyzer;

        [SetUp]
        public void Setup()
        {
            IOptions<GoogleSearchAnalyzerOptions> options = Options.Create<GoogleSearchAnalyzerOptions>(new GoogleSearchAnalyzerOptions
            {
                BaseSearchUri = "http://www.test.com",
                CheckTopResults = 10,
                MatchUris = new string[] { "test.com", "www.test.com", "http://www.test.com" }
            }); 


            searchResultsAnalyzer = new GoogleSearchAnalyzer(new MockPageScraper(), new MockGoogleSearchResultsParser(), options);
        }

        [TestCase("test.com")]
        [TestCase("www.test.com")]
        [TestCase("http://www.test.com")]
        public async Task GoogleSearchAnalyzer_ShouldReturn6Results(string matchUri)
        {
            var result = await searchResultsAnalyzer.SearchResultRankingsAsync("test search", matchUri);

            Assert.AreEqual("1, 3, 5, 6, 8, 10", result.Rankings);
        }
    }
}
