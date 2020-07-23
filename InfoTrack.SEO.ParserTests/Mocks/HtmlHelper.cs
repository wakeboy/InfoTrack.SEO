using InfoTrack.SEO.Parser.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.SEO.ParserTests.Mocks
{
    public class MockHtmlHelper : IHtmlHelper
    {
        public string FindElementByCssClass(string html, string element, string cssClass)
        {
            return "<a class=\"next-link\" href=\"/search?q=test\">Next Link</a>";
        }

        public List<string> FindElementsByCssClass(string html, string element, string cssClass)
        {
            return new List<string> {
                "<div class=\"result\" aria-label=\"Result 1\">Result 1</div>",
                "<div class=\"result\">Result 2</div>",
                "<div class=\"result\">Result 3</div>",
                "<div class=\"result\">Result 4</div>",
                "<div class=\"result\">Result 5</div>"
            };
        }

        public string GetHtmlAttributeValue(string html, string attributeName)
        {
            return "/search?q=test";
        }

        public string RemoveHtmlTags(string html)
        {
            throw new NotImplementedException();
        }
    }
}
