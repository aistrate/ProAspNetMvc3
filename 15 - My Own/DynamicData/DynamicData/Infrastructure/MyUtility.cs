using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicData.Infrastructure
{
    public class MyUtility
    {
        public static string GetUsefulData()
        {
            return "<form>Enter your password:<input type=text><input type=submit value=\"Log In\"/></form>";
        }

        public static MvcHtmlString GetUnencodedData()
        {
            return new MvcHtmlString(GetUsefulData());
        }
    }
}