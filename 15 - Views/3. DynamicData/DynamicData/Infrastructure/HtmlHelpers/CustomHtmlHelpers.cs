using System.Web.Mvc;

namespace DynamicData.Infrastructure.HtmlHelpers {

    public static class CustomHtmlHelpers {

        public static MvcHtmlString List(this HtmlHelper html, string[] listItems) {

            TagBuilder tag = new TagBuilder("ul");

            foreach (string item in listItems) {

                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(item);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }
    }
}