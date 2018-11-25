using ControllersBasics.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasics.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetImage()
        {
            string path = "../Content/Images/frontend.jpg";
            return new ImageResult(path);
        }


        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostBook ()
        {
            string title = Request.Form["title"];
            string author = Request.Form["author"];
            return Content(title + " " + author);
        }

        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a*h/2;
            return "<h2>Площадь треугольника с основанием " + a + " и высотой " + h + " равна " + s + "</h2>";
        }

        public string GetId(int id)
        {
            return id.ToString();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}