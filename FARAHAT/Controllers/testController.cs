using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    public class testController : Controller
    {
        // GET: test
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult index2()
        {
            
            var x = Session["Name"];
            return View();
        }

    }
}