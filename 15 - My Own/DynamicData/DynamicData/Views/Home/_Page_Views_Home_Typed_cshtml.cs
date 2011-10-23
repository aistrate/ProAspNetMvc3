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

    public class _Page_Views_Home_Typed_cshtml : System.Web.Mvc.WebViewPage<string>
    {

        public _Page_Views_Home_Typed_cshtml()
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

            WriteLiteral("\r\n");

            ViewBag.Title = "Typed";

            WriteLiteral("\r\n<h2>Typed</h2>\r\n\r\nModel: ");

            Write(Model);

            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n<br />\r\n\r\n");

            foreach (string s in new string[] { "a", "b" })
            {
                string t = s + s;

                WriteLiteral("    ");

                WriteLiteral("Value1: ");

                Write(s);

                WriteLiteral(" (s)\r\n");

                Write(3 + 5);

                WriteLiteral("    <p>\r\n        Value2: ");

                Write(t);

                WriteLiteral(" (t)\r\n    </p>\r\n");
            }

            WriteLiteral("\r\nEnd\r\n\r\n");

            Write(5 + 7);

            WriteLiteral("\r\n\r\n");

            Write(10 + 15);

            WriteLiteral("\r\n");

            if (true) { }

            if (true) { ; }

            if (true) { var x = "d"; }

            WriteLiteral("\r\n<br />\r\n");

            if (true)
            {
                var x = "e";

                Write(x + x);

                Write(x);
            }

            WriteLiteral("\r\n<br />\r\n");

            if (true)
            {
                var x = "f";

                Write(x + x);

                WriteLiteral(" ");

                WriteLiteral("-- -- ");

                Write(x);

                WriteLiteral(" ");

                Write(x);

                WriteLiteral("\r\n");
            }
        }
    }
}
