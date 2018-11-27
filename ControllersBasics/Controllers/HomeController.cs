using ControllersBasics.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersBasics.Controllers
{
    public class HomeController : Controller
    {
        public FilePathResult GetFile()
        {
            string file_path = Server.MapPath("~/Files/test.txt");
            //string path= "C://files//test.txt";
            string file_type = "application/octet-stream";
            string file_name = "test.txt";
            return File(file_path, file_type, file_name);
        }

        public FileContentResult GetBytes()
        {
            string path = Server.MapPath("~/Files/test.txt");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/txt";
            string file_name = "test.txt";
            return File(mas, file_type, file_name);
        }

        public FileStreamResult GetStream()
        {
            string path = Server.MapPath("~/Files/test.txt");
            //Объект Stream
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "application/txt";
            string file_name = "test.txt";
            return File(fs, file_type, file_name);
        }

        public ViewResult Index()
        {
            //ViewData["Head"] = "Привет, мир!";
            ViewBag.Head = "Привет, мир!";
            ViewBag.Fruit = new List<string>
            {
                "яблоки", "груши", "вишни"
            };
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

        public ActionResult GetVoid(int id)
        {
            if (id > 3)
            {
                // return RedirectToAction("Square", "Home", new { a = 10, h = 12});
                return new HttpUnauthorizedResult();
            }
            return View("About");
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