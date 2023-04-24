using FARAHAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    public class courseLessonController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: courseLesson
        public ActionResult Index(int id)
        {
            var ss = context.CourseLessons.Where(c => c.course_ID == id).ToList();
            TempData["id"] = id;
            TempData.Keep("id");
            return View(ss);
        }

        // GET: courseLesson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: courseLesson/Create
        public ActionResult Create()
        {
            ViewBag.courseId = TempData["id"];
            return View();
        }

        // POST: courseLesson/Create
        [HttpPost]
        public ActionResult Create(CourseLesson courseLesson)
        {
            //CourseLesson courseLesson1 = new CourseLesson();
            
            //courseLesson1.course_ID = courseLesson.course_ID;
            //courseLesson1.Title = courseLesson.Title;
            //courseLesson1.OrderNember = courseLesson.OrderNember;
            context.CourseLessons.Add(courseLesson);
            context.SaveChanges();

                return RedirectToAction("Index",new {id=courseLesson.course_ID });
          
        }

        // GET: courseLesson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: courseLesson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: courseLesson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: courseLesson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
