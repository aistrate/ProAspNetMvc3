using System.Web.Mvc;

namespace DynamicData.Infrastructure {
    public class MyUtility {

        public static string GetUsefulData() {

            return "<form>Enter your password:<input type=text><input type=submit value=\"Log In\"/></form>";
        }

        //public static MvcHtmlString GetUsefulData() {

        //    return new MvcHtmlString("<form>Enter your password:<input type=text><input type=submit value=\"Log In\"/></form>");
        //}
    }
}