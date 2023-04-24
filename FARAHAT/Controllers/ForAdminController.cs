using FARAHAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ForAdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: ForAdmin
        public ActionResult Index()
        {
            ViewBag.AllCategory = context.Categories.Count();
            ViewBag.AllCourses = context.Courses.Count();
            ViewBag.AllUsers = context.Users.Count();
            ViewBag.AllTrainer = context.Trainers.Count();

            return View();
        }
    }
}