using System.Web.Mvc;
using Ninject;

namespace Views.Models.ViewClasses
{
    public abstract class CalculatorView : WebViewPage
    {
        [Inject]
        public ICalculator Calculator { get; set; }
    }
}