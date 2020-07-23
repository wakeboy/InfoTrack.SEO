using System.Text.RegularExpressions;

namespace InfoTrack.SEO.Parser.Models
{
    public abstract class SearchResult
    {
        public SearchResult(string html)
        {
            Html = html;
        }

        public virtual string Uri { 
            get
            {
                if (string.IsNullOrEmpty(Html))
                    return string.Empty;

                return ExtractResultUri();
            }
        }

        public string Html { get; }

        private string ExtractResultUri()
        {
            var removeTags = new Regex("<[^>]*>");
            var uri = removeTags.Replace(Html, string.Empty);
            var endIndex = uri.IndexOf(' ') > -1 ? Html.IndexOf(' ') : Html.Length;
            return uri.Substring(0, endIndex);
        }
    }
}
