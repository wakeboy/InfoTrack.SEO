using System.Collections.Generic;

namespace InfoTrack.SEO.Web.Configuration
{
    public class GoogleSearchAnalyzerOptions
    {
        public const string SettingsKey = "GoogleSearchAnalyzerOptions";
        public string BaseSearchUri { get; set; }
        public int CheckTopResults { get; set; }
        public List<string> MatchUris { get; set; }
    }
}
