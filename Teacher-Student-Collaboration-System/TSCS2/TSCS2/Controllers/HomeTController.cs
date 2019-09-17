using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSCS2.Controllers
{
    public class HomeTController : Controller
    {
        // GET: HomeT
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCourse() {
            return View();
        }
    }
}