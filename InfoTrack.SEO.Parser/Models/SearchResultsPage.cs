using System.Collections.Generic;

namespace InfoTrack.SEO.Parser.Models
{
    public class SearchResultsPage
    {
        public List<SearchResult> SearchResults { get; set; }
        public string NextPageUri { get; set; }
    }
}
