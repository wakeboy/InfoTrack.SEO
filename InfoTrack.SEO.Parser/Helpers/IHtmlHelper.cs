using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.SEO.Parser.Helpers
{
    public interface IHtmlHelper
    {
        List<string> FindElementsByCssClass(string html, string element, string cssClass);
        string FindElementByCssClass(string html, string element, string cssClass);
        string GetHtmlAttributeValue(string html, string attributeName);
        string RemoveHtmlTags(string html);
    }
}
