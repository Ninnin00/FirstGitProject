using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApplication.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        //public string Index()
        //{
        //    return "This is my <b>default</b> action...";
        //}

        //
        //GET: HelloWord/Welcome
        public ActionResult Welcome(string name, string hh, int ID=1)
        {
            //return "This is the Welcome action method...";
            //return HttpUtility.HtmlEncode("Hello "+name+",This is your "+ID+" to visit!"+hh);
            ViewBag.Message = "Hello " + name;
            ViewBag.times = ID;
            return View();
        }
    }
}