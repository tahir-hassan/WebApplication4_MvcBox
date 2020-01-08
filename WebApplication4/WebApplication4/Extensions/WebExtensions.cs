using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Extensions
{
    public class BoxDisposable : IDisposable
    {
        private HtmlHelper htmlHelper;

        public BoxDisposable(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public void Dispose()
        {
            this.htmlHelper.ViewContext.Writer.Write("</div>");
        }
    }

    public static class WebExtensions
    {
        private static void Write(this HtmlHelper htmlHelper, string stringToWrite)
        {
            htmlHelper.ViewContext.Writer.Write(stringToWrite);
        }

        public static BoxDisposable Box(this HtmlHelper htmlHelper, string title)
        {
            htmlHelper.Write("<div>");
            htmlHelper.Write("<p>" + htmlHelper.Encode(title) + "</p>");
            htmlHelper.Write("<div>");
            return new BoxDisposable(htmlHelper);
        }

    }
}