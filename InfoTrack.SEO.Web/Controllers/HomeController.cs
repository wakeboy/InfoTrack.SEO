using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InfoTrack.SEO.Web.Models;
using InfoTrack.SEO.Web.Analyzers;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchResultsAnalyzer searchResultsAnalyzer;

        public HomeController(ISearchResultsAnalyzer searchResultsAnalyzer)
        {
            this.searchResultsAnalyzer = searchResultsAnalyzer;
        }

        public async Task<IActionResult> Index([FromQuery(Name = "term")] string term)
        {
            var model = new SEORankingModel
            {
                Term = term
            };

            if (!string.IsNullOrEmpty(term))
            {
                model = await searchResultsAnalyzer.SearchResultRankings(term);
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
