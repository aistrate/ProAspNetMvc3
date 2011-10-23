using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace ViewEngines.Infrastructure.CustomViewEngine
{
    public class DebugDataView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            writeDictionary(writer, "Routing Data:", viewContext.RouteData.Values);
            Write(writer, "");
            writeDictionary(writer, "View Data:", viewContext.ViewData);
        }

        private void writeDictionary(TextWriter writer, string heading, IDictionary<string, object> dict)
        {
            Write(writer, heading);
            foreach (var pair in dict)
                Write(writer, "- Key: {0}; Value: {1}", pair.Key, pair.Value);
        }

        private void Write(TextWriter writer, string format, params object[] args)
        {
            writer.Write(string.Format(format, args) + "<br />\n");
        }
    }
}