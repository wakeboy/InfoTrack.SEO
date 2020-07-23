using InfoTrack.SEO.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Web.Analyzers
{
    public interface ISearchResultsAnalyzer
    {
        Task<SEORankingModel> SearchResultRankings(string searchTerm);
    }
}
