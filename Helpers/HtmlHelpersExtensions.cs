using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Umbraco.Cms.Core.Strings;

namespace DebayTechnics.Helpers;

public static class HtmlHelpersExtensions
{
    public static IHtmlContent RichTxtToHtml(this IHtmlHelper htmlHelper, IHtmlEncodedString richTxt)
    {
        return new HtmlString(richTxt.ToHtmlString()
            .Replace("<li>", "<li><i class='bi bi-check-circle'></i> <span>")
            .Replace("</li>","</span></li>"));
    }
}