using System.Web.Mvc;

namespace DynamicData.Infrastructure.HtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        public static MvcHtmlString List(this HtmlHelper helper, string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");

            foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }

            return new MvcHtmlString(ul.ToString());
        }
    }
}