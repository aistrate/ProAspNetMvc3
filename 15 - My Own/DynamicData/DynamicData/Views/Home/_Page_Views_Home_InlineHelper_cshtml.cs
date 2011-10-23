namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using DynamicData.Infrastructure;

    public class _Page_Views_Home_InlineHelper_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public System.Web.WebPages.HelperResult CreateList(string[] items)
        {
            return new System.Web.WebPages.HelperResult(__razor_helper_writer =>
            {
                WriteLiteralTo(@__razor_helper_writer, "    <ul>\r\n");

                foreach (string item in items)
                {
                    WriteLiteralTo(@__razor_helper_writer, "            <li>");

                    WriteTo(@__razor_helper_writer, item);

                    WriteLiteralTo(@__razor_helper_writer, "</li>\r\n");
                }

                WriteLiteralTo(@__razor_helper_writer, "    </ul>\r\n");
            });
        }

        public _Page_Views_Home_InlineHelper_cshtml()
        {
        }

        protected ASP.global_asax ApplicationInstance
        {
            get
            {
                return ((ASP.global_asax)(Context.ApplicationInstance));
            }
        }

        public override void Execute()
        {
            ViewBag.Title = "InlineHelper";

            WriteLiteral("\r\n");

            WriteLiteral("\r\n\r\n<h2>InlineHelper</h2>\r\n\r\nDays of the week: <p />\r\n");

            Write(CreateList(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames));

            WriteLiteral("\r\n\r\n<p />\r\nFruit I like: <p />\r\n");

            Write(CreateList(ViewBag.Fruits));

            WriteLiteral("\r\n");
        }
    }
}
