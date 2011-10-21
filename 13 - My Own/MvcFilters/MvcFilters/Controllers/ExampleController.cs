using System;
using System.Web.Mvc;
using MvcFilters.Infrastructure.Filters;

namespace MvcFilters.Controllers
{
    public class ExampleController : Controller
    {
        //[CustomAuth("adam", "steve", "bob")]
        //[Authorize(Users="adam, steve, bob", Roles="admin"]
        [OrAuthorizatin(Users = "adam, steve, bob", Roles = "admin")]
        //[AjaxAuthorize(Users = "adam, steve, bob", Roles = "admin")]
        //[RequireHttps]
        public ViewResult Index()
        {
            return View();
        }

        [CustomException]
        public ViewResult NullRef()
        {
            return View();
        }

        // Works only with <customErrors mode="On">
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "SpecialError")]
        public ViewResult NullRef2()
        {
            return View("NullRef");
        }

        [CustomActionFilter]
        public ViewResult Index2()
        {
            return View("Index");
        }

        [ProfileAction]
        [ProfileResult]
        public ViewResult Timed()
        {
            return View("Index");
        }

        [ProfileAll]
        public ViewResult Timed2()
        {
            return View("Index");
        }
    }
}
