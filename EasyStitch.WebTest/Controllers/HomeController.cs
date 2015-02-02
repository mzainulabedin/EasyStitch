using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyStitch.WebTest.Controllers
{
    public class HomeController : Controller
    {
        //// GET: Home
        //public ContentResult Index()
        //{
        //    return this.Content("working");
        //}

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}