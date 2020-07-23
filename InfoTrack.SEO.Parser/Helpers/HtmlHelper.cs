using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InfoTrack.SEO.Parser.Helpers
{
    public class HtmlHelper : IHtmlHelper
    {
        public List<string> FindElementsByCssClass(string html, string element, string cssClass)
        {
            if (string.IsNullOrEmpty(html))
                throw new ArgumentNullException(nameof(html), "Cannot be null or empty.");

            if (string.IsNullOrEmpty(element))
                throw new ArgumentNullException(nameof(element), "Cannot be null or empty.");

            if (string.IsNullOrEmpty(cssClass))
                throw new ArgumentNullException(nameof(cssClass), "Cannot be null or empty.");

            Regex resultLinks = new Regex($@"<{element} [^>]*class=""{cssClass}""[^>]*>(.*?)<\/{element}>");
            return resultLinks.Matches(html)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToList();
        }

        public string FindElementByCssClass(string html, string element, string cssClass)
        {
            if (string.IsNullOrEmpty(html))
                throw new ArgumentNullException(nameof(html), "Cannot be null or empty.");

            if (string.IsNullOrEmpty(element))
                throw new ArgumentNullException(nameof(element), "Cannot be null or empty.");

            if (string.IsNullOrEmpty(cssClass))
                throw new ArgumentNullException(nameof(cssClass), "Cannot be null or empty.");

            Regex resultLinks = new Regex($@"<{element} [^>]*class=""{cssClass}""[^>]*>(.*?)<\/{element}>");
            return resultLinks.Match(html)
                .Value;
        }

        public string GetHtmlAttributeValue(string html, string attributeName)
        {
            if (string.IsNullOrEmpty(html))
                throw new ArgumentNullException(nameof(html), "Cannot be null or empty.");

            if (string.IsNullOrEmpty(attributeName))
                throw new ArgumentNullException(nameof(attributeName), "Cannot be null or empty.");

            Regex regex = new Regex($@"(?<=\b{attributeName}="")[^""]*");
            Match match = regex.Match(html);
            return match.Value;
        }

        public string RemoveHtmlTags(string html)
        {
            if (string.IsNullOrEmpty(html))
                throw new ArgumentNullException(nameof(html), "Cannot be null or empty.");

            var removeTags = new Regex("<[^>]*>");
            return removeTags.Replace(html, string.Empty);
        }
    }
}
