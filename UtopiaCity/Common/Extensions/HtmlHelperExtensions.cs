using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace UtopiaCity.Common.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            var tagBuilder = new TagBuilder("ul");
            foreach (var item in items)
            {
                var innerTagBuilder = new TagBuilder("li");
                innerTagBuilder.InnerHtml.Append(item);
                tagBuilder.InnerHtml.AppendHtml(innerTagBuilder);
            }

            tagBuilder.Attributes.Add("class", "list");
            var writer = new StringWriter();
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
