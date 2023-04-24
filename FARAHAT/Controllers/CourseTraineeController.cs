using FARAHAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    public class CourseTraineeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: CourseTrainee
        public ActionResult Index(int id)
        {
            var sasa = context.CourseTrainees.Where(c => c.CourseId == id).ToList();
            List<ApplicationUser> users = new List<ApplicationUser>();
            int y = 0;
            foreach(var item in sasa)
            {
                ApplicationUser user2 = context.Users.FirstOrDefault(c => c.Id == item.UserId);
                users.Add(user2);
            }
            
            
            // var sg = context.CourseTrainees.Where(c => c.CourseId == id).ToList();

          //  var dd = context.Users.Where(c => c.Id == sg.UserId);
           // var query = context.Users.Select(c => c.Id ==)
           //var query = from Users in context.Users
           //            select Users
           //          where User.Id ==

           //  var ss = context.Users.Where(c => c.Id == (context.CourseTrainees.Where(f => f.CourseId == id))).ToList();
           // List<ApplicationUser> users = context.Users.FirstOrDefault
            return View(users);
        }
    }
}