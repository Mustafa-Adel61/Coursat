using FARAHAT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult userProfile(string id)
        {

            TempData["asd"] = id;
            TempData.Keep("asd");
            ApplicationUser User = context.Users.FirstOrDefault(c => c.Id == id);
            return View(User);
        }
        [HttpPost]
        public ActionResult EditProfile(ApplicationUser user, HttpPostedFileBase ImageFile)
        {
            //مش عارف ليه مش بيوصل لل user باستخدام user.id لكن هنا جبت ال user الي فوق
            string f = TempData["asd"].ToString();
            ApplicationUser User = context.Users.FirstOrDefault(c => c.Id == f);
            //////////////////////////////////////////////////////////
            if (ImageFile != null)
            {
                //string oldFilePath = Server.MapPath($"~/Content/upload/profile/{user1.Image_ID}");
                //System.IO.File.Delete(oldFilePath);
                /////////////////////////////////////////
                var fileExtention = Path.GetExtension(ImageFile.FileName);
                var imageGuid = Guid.NewGuid().ToString();
                user.Image_ID = imageGuid + fileExtention;
                string filePath = Server.MapPath($"~/Content/upload/profile/{user.Image_ID}");
                ImageFile.SaveAs(filePath);
                User.Image_ID = user.Image_ID;
            }

            /////////////////////////////////////////////////////////
            ///
            User.country = user.country;
            User.gender = user.gender;
            User.PhoneNumber = user.PhoneNumber;
            context.SaveChanges();
            return RedirectToAction("userProfile",new {id=f });
        }
       public ActionResult userCourses(string id)
        {
            var sasa = context.CourseTrainees.Where(c => c.UserId == id).ToList();
            //List<ApplicationUser> users = new List<ApplicationUser>();
            List<Course> courses = new List<Course>();
            foreach (var item in sasa)
            {
               // ApplicationUser user2 = context.Users.FirstOrDefault(c => c.Id == item.UserId);
                Course courses1 = context.Courses.FirstOrDefault(c => c.ID == item.CourseId);
                courses.Add(courses1);
            }
           
            return View(courses);
        }
        public ActionResult Index()
        {
            var s = context.Categories.ToList();
            return View(s);
        }
         public ActionResult courses(int? id)
        {
            var s = context.Courses.Where(c=>c.category_ID==id).ToList();
            Category category = context.Categories.FirstOrDefault(c => c.ID == id);
             
            ViewBag.catecory = category.Name;
            return View(s);
        }
        public ActionResult mycourses(int id)
        {
            var m = User.Identity.GetUserId();
            var s = context.CourseTrainees.Where(c => c.CourseId == id).ToList();
            if (s != null)
            {
                foreach (var item in s)
                {
                    if ( item.UserId == m)
                    {
                        ViewBag.alreadysubscribe = "Subscriped";
                        TempData["unsubscrip"] = item.C_ID;
                      

                    }

                }
            }
            ViewBag.addsuccessfly = TempData["addsuccessfly"];
            ViewBag.unsubscripsuccessfly = TempData["unsubscripsuccessfly"];
            var ss = context.Courses.FirstOrDefault(c => c.ID == id);
            ViewBag.imageId =ss.Image_ID;
            ViewBag.Name = ss.Name;
            ViewBag.Description = ss.Description;
            ViewBag.courseId = ss.ID;
            ViewBag.thiscourse = ss.Name;

            var sasa = context.CourseLessons.Where(c => c.course_ID == id).ToList();
            

            return View(sasa);
        }

      
        //public ActionResult subscrip(int id)
        //{



        //    if (!Request.IsAuthenticated)
        //    {//returnUrl المكان الي هيرجع ليه بعد ما يعمل login
        //        return RedirectToAction("Login", "Account", new { returnUrl = $"/Home/subscrip/{id}" });
        //      //  return Content("Authenticated");
        //    }
        //    else
        //    {
        //        CourseTrainee courseTrainee = new CourseTrainee();
        //        courseTrainee.CourseId = id;
        //        // courseTrainee.UserId=
        //        //string userId = Convert.ToString(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        //        //var email = User.FindFirst("sub")?.Value);
        //        // var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //        var sasa = User.Identity.Name;
        //        courseTrainee.UserId = sasa;

        //        ApplicationUser user = UserManager.FindByName(sasa);

        //        context.CourseTrainees.Add(courseTrainee);
        //        context.SaveChanges();

        //        return Content(" Authenticated");
        //    }
        //   // return View();
        //}

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