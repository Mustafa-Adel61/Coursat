using FARAHAT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    public class CourseController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Course
        public ActionResult Index()
        {
            ViewBag.Category = context.Categories.ToList();

            var s = context.Courses.ToList();
            return View(s);
        }
        [HttpPost]
        public ActionResult searchByCategory(string name)
        {
            var cc = context.Courses.Where(c => c.CategoryName.ToLower() == name.ToLower()).ToList();
            return View(cc);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Course course = context.Courses.FirstOrDefault(c => c.ID == id);
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.Category = context.Categories.ToList();
            ViewBag.Trainer = context.Trainers.ToList();
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course, HttpPostedFileBase ImageFile)
        {
            
            //لازم اعملهم هنا تاني عشان ال validation لو رجعت false
            ViewBag.Category = context.Categories.ToList();
            ViewBag.Trainer = context.Trainers.ToList();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(course);
                }
                else
                {//ه check هو حط صوره ولا لا 
                 //if (course.ImageFile == null || course.ImageFile.ContentLength == 0)
                 //{
                 //    return View(course);
                 //}
                    if (ImageFile == null || ImageFile.ContentLength == 0)
                    {
                        return View(course);
                    }
                    //var fileExtention = Path.GetExtension(course.ImageFile.FileName);
                    var fileExtention = Path.GetExtension(ImageFile.FileName);
                    var imageGuid = Guid.NewGuid().ToString();
                    //course.picture_ID = imageGuid + fileExtention;
                    course.Image_ID = imageGuid + fileExtention;
                    //string filePath = Server.MapPath($"~/Content/upload/courses/{course.picture_ID}");
                    string filePath = Server.MapPath($"~/Content/upload/courses/{course.Image_ID}");
                   // course.ImageFile.SaveAs(filePath);
                    ImageFile.SaveAs(filePath);

                    if (context.Courses.Where(c => c.Name.ToLower() == course.Name.ToLower()).Any())
                    {
                        ViewBag.message = "This course is Already Exist!";
                        return View(course);
                    }
                    else
                    {//بعد ما رفعت صوره هتاكد انها اترفعت وال size مسمحوح بيه
                        //if (Request.Form.Count > 0)
                        //{
                        //    var file = Request.FormFirstOrDefault();
                        //}
                        Category category = context.Categories.FirstOrDefault(c => c.ID == course.category_ID);
                        Trainer trainer = context.Trainers.FirstOrDefault(c => c.ID == course.trainer_ID);
                        course.CategoryName = category.Name;
                        course.TrainerName = trainer.Name;
                        course.Creation_Date = DateTime.Now;
                        Course course1 = new Course();
                       
                      //  //عملت كدا عشان اضيف الصوره
                      ////  course1.ID = course.ID;
                      //  course1.Name = course.Name;
                      //  course1.picture_ID = course.picture_ID;
                      //  course1.TrainerName = course.TrainerName;
                      //  course1.trainer_ID = course.trainer_ID;
                      //  course1.category_ID = course.category_ID;
                      //  course1.CategoryName = course.CategoryName;
                      //  course1.Creation_Date = course.Creation_Date;
                      //  course1.Description = course.Description;
                      //  context.Courses.Add(course1);
                        context.Courses.Add(course);
                        context.SaveChanges();
                        
                       return RedirectToAction("Index");
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = context.Courses.FirstOrDefault(c => c.ID == id);
            ViewBag.Category = context.Categories.ToList();
            ViewBag.Trainer = context.Trainers.ToList();
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(Course course, HttpPostedFileBase ImageFile=null)
        {//عملت ال ImageFile ب null عشان ا check هو ضاف حاجه جديده كدا هتتغير لو مضافش هتفضل ب null
            ViewBag.Category = context.Categories.ToList();
            ViewBag.Trainer = context.Trainers.ToList();
            try
            {
                Course course2 = context.Courses.FirstOrDefault(c => c.ID == course.ID);
                if (course2 != null && course.ID != course.ID)
                {
                    ViewBag.success = true;

                    ViewBag.message = "this Course is Already Exist!";
                    return View(course);
                }
                else
                {
                    
                    //معني كدا انه ضاف صوره جديده غير القديمه 
                    //لة مضافش هخليه القديمه زي ماهي لكن لو ضاف هحذف القديمه واحط دي
                   //delete old image and add new 
                    if (ImageFile != null)
                    {
                        string oldFilePath=Server.MapPath($"~/Content/upload/courses/{course2.Image_ID}");
                        System.IO.File.Delete(oldFilePath);
                        /////////////////////////////////////////
                        var fileExtention = Path.GetExtension(ImageFile.FileName);
                        var imageGuid = Guid.NewGuid().ToString();
                        course.Image_ID = imageGuid + fileExtention;
                        string filePath = Server.MapPath($"~/Content/upload/courses/{course.Image_ID}");
                        ImageFile.SaveAs(filePath);
                        course2.Image_ID = course.Image_ID;
                    }
                    ViewBag.message = $"Course {course.ID} is Updated successfully ";
                   
                    Category category = context.Categories.FirstOrDefault(c => c.ID == course.category_ID);
                    Trainer trainer = context.Trainers.FirstOrDefault(c => c.ID == course.trainer_ID);
                    course2.Name = course.Name;
                    course2.Description = course.Description;
                    course2.category_ID = course.category_ID;
                    //عشان انا من view او ال drowpDownListهاخد ال categoryId وال TrainerID بس فلازم اجيب ال name
                    course2.CategoryName = category.Name;
                    course2.TrainerName = trainer.Name;
                    context.SaveChanges();

                    return View(course);
                }

            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Delete(int id)
        {
            Course course = context.Courses.FirstOrDefault(c => c.ID == id);
            context.Courses.Remove(course);
            context.SaveChanges();

                return RedirectToAction("Index");
           
        }
    }
}
