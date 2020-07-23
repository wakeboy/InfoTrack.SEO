using InfoTrack.SEO.Parser.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.SEO.ParserTests.Helpers
{
    public class HtmlHelperTests
    {
        private IHtmlHelper htmlHelper;

        [OneTimeSetUp]
        public void Setup()
        {
            this.htmlHelper = new HtmlHelper();
        }

        [Test]
        public void FindElementsByCssClass_ShouldFindElements()
        {
            var testClassName = "result";

            var result = htmlHelper.FindElementsByCssClass(TestValidHtml(), "div", testClassName);

            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void FindElementsByCssClass_ShouldNotFindElements()
        {
            var testClassName = "result";

            var result = htmlHelper.FindElementsByCssClass(TestInValidHtml(), "div", testClassName);

            Assert.AreEqual(0, result.Count);
        }

        [TestCase("<div></div>", "div", "")]
        [TestCase("<div></div>", "", "class")]
        [TestCase("", "div", "class")]
        [TestCase("<div></div>", "", "")]
        [TestCase("", "", "class")]
        [TestCase("", "", "")]
        public void FindElementsByCssClass_ShouldThrowExceptionWhenParameterNullOrEmpty(string html, string element, string cssClass)
        {
            Assert.Throws<ArgumentNullException>(() => htmlHelper.FindElementsByCssClass(html, element, cssClass));
        }

        [TestCase("<div></div>", "div", "")]
        [TestCase("<div></div>", "", "class")]
        [TestCase("", "div", "class")]
        [TestCase("<div></div>", "", "")]
        [TestCase("", "", "class")]
        [TestCase("", "", "")]
        public void FindElementByCssClass_ShouldThrowExceptionWhenParameterNullOrEmpty(string html, string element, string cssClass)
        {
            Assert.Throws<ArgumentNullException>(() => htmlHelper.FindElementByCssClass(html, element, cssClass));
        }

        [TestCase("<div></div>", "")]
        [TestCase("", "class")]
        [TestCase("", "")]
        public void GetHtmlAttributeValue_ShouldThrowExceptionWhenParameterNullOrEmpty(string html, string attributeName)
        {
            Assert.Throws<ArgumentNullException>(() => htmlHelper.GetHtmlAttributeValue(html, attributeName));
        }

        [Test]
        public void FindElementByCssClass_ShouldFindElement()
        {
            var testClassName = "next-link";

            var result = htmlHelper.FindElementsByCssClass(TestValidHtml(), "a", testClassName);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void FindElementByCssClass_ShouldNotFindElement()
        {
            var testClassName = "next-link";

            var result = htmlHelper.FindElementsByCssClass(TestInValidHtml(), "a", testClassName);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetHtmlAttributeValue_ShouldRerturnHrefValue()
        {
            var html = @"<a class=""next-link"" href=""/serach?q=test"" aria-label=""Next Link"">Next Link</a>";
            var attributeName = "href";

            var result = htmlHelper.GetHtmlAttributeValue(html, attributeName);

            Assert.AreEqual("/serach?q=test", result);
        }

        [Test]
        public void GetHtmlAttributeValue_ShouldNotRerturnHrefValue()
        {
            var html = @"<a class=""next-link"" href=""/serach?q=test"" aria-label=""Next Link"">Next Link</a>";
            var attributeName = "id";

            var result = htmlHelper.GetHtmlAttributeValue(html, attributeName);

            Assert.AreEqual("", result);
        }

        [Test]
        public void RemoveHtmlTags_ShouldRemoveHtmlTags()
        {
            var html = @"<a href=""test""><div>test</div></a>";

            var result = htmlHelper.RemoveHtmlTags(html);

            Assert.AreEqual("test", result);
        }


        private string TestValidHtml()
        {
            return @"
<html>
    <head>
        <title>Test MarkuupTitle</title>
    </head>
    <body>
        <header>
            <h1>Header</h1>
        </header>
        <div class=""content"">
            <div class=""search-result"">
                <div class=""result"" aria-label=""Result 1"">Result 1</div>
                <div class=""result"">Result 2</div>
                <div class=""result"">Result 3</div>
                <div class=""result"">Result 4</div>
                <div class=""result"">Result 5</div>
            </div>
            <div class=""pagination"">
                <a class=""next-link"" href=""/serach?q=test"" aria-label=""Next Link"">Next Link</a>
            </div>
        </div>
        <footer>
            <div>Content</div>
        </footer>
    </body>
</html>";
        }

        private string TestInValidHtml()
        {
            return @"
<html>
    <head>
        <title>Test MarkuupTitle</title>
    </head>
    <body>
        <header>
            <h1>Header</h1>
        </header>
        <div class=""content"">
            <div class=""search-result"">
            </div>
        </div>
        <footer>
            <div>Content</div>
        </footer>
    </body>
</html>";
        }


    }
}
