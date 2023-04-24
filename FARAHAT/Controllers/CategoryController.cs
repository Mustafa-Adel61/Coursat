using FARAHAT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
            ApplicationDbContext context = new ApplicationDbContext();
        //دا الي بعرض فيه ال list من ال catogray الي موجوده في ال DB
        public ActionResult Index()
        {//في ال view عايزها حجه بتدعم ال IEnumerable في هنا ال List مثلا
            ViewBag.AllCategory = context.Categories.Count();
            List<Category> s = context.Categories.ToList();
            //List<Category> categories = new List<Category>();

            return View(s);
        }
        //هعمل catogry جديده هنا
        public ActionResult create()
        {
            ViewBag.Category = context.Categories.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult create(Category category, HttpPostedFileBase ImageFile)
        {//لاحظ عملت ال viewBag هنا وفوق عشان لو كتب حاجه موجوده قبل كدا هيعمل هنا 
            //ان viewBag فاضيه لازم املاها تاني 
            ViewBag.Category = context.Categories.ToList();
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {//هشوف لو موجةد قبل كدا في DBولا لا

                if (context.Categories.Where(c => c.Name.ToLower() == category.Name.ToLower()).Any())
                {
                    ViewBag.message = "This Category is Already Exist ";
                    return View(category);
                }
                else
                {
                    if (ImageFile == null || ImageFile.ContentLength == 0)
                    {
                        return View(category);
                    }
                    //var fileExtention = Path.GetExtension(course.ImageFile.FileName);
                    var fileExtention = Path.GetExtension(ImageFile.FileName);
                    var imageGuid = Guid.NewGuid().ToString();
                    //course.picture_ID = imageGuid + fileExtention;
                    category.Image_ID = imageGuid + fileExtention;
                    //string filePath = Server.MapPath($"~/Content/upload/courses/{course.picture_ID}");
                    string filePath = Server.MapPath($"~/Content/upload/category/{category.Image_ID}");
                    // course.ImageFile.SaveAs(filePath);
                    ImageFile.SaveAs(filePath);
                    var ss = context.Categories.FirstOrDefault(c => c.ID == category.parent_ID);
                    if (ss != null)
                    {
                        category.parent_Name = ss.Name;
                    }
                    context.Categories.Add(category);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
            }
        }
        public ActionResult Edit(int id)
        {
            var ss = context.Categories.FirstOrDefault(c => c.ID == id);
            //عشان في ال dropdownlistيشيل الحاجه الي عامل ال edit ليها عشان ميكون في حاجه parent لنفسها
            //var dd = context.Categories.FirstOrDefault(c => c.ID == id);
            //context.Categories.Remove(dd);
            ViewBag.Category = context.Categories.ToList();

            return View(ss);
        }
        [HttpPost]
        public ActionResult Edit(Category category, HttpPostedFileBase ImageFile = null)
        {
            ViewBag.Category = context.Categories.ToList();

            //عايز اشوف هل هي موجود قبل كدا ب id مختلف ولا لا
            //where بترجع bool مش catogray
            //عملت كدا عشان ممكن يقولي انها موجوده بس هو اصلا مفيش غيرها الي بعدل فيها ف check علي hID
            Category category2 = context.Categories.FirstOrDefault(c => c.Name.ToLower() == category.Name.ToLower());

            if (category2!=null&&category2.ID!=category.ID)
            {
                ViewBag.success = true;
                ViewBag.message = "This Category is Already Exist ";
                return View(category);
            }
            else
            {
               
                ViewBag.message = $"Category {category.ID} is Updated successfully ";

                Category category1 = context.Categories.FirstOrDefault(c=>c.ID==category.ID);
                if (ImageFile != null)
                {
                    if (category1.Image_ID != null)
                    {
                        string oldFilePath = Server.MapPath($"~/Content/upload/category/{category1.Image_ID}");
                        System.IO.File.Delete(oldFilePath);
                    }
                    /////////////////////////////////////////
                    var fileExtention = Path.GetExtension(ImageFile.FileName);
                    var imageGuid = Guid.NewGuid().ToString();
                    category.Image_ID = imageGuid + fileExtention;
                    string filePath = Server.MapPath($"~/Content/upload/category/{category.Image_ID}");
                    ImageFile.SaveAs(filePath);
                    category1.Image_ID = category.Image_ID;
                }

                // category1.ID = category.ID;
                category1.Name = category.Name;
                category1.parent_ID = category.parent_ID;
                var ss = context.Categories.FirstOrDefault(c => c.ID == category.parent_ID);
                if (ss != null)
                {
                    category1.parent_Name = ss.Name;
                }
                else
                {
                    category1.parent_Name = "";

                }
                context.SaveChanges();
                // return RedirectToAction("Index", "Category");
                return View(category);
            }

        }
        public ActionResult Details(int id)
        {
            Category category = context.Categories.FirstOrDefault(c => c.ID == id);
            return View(category);
        }
        public ActionResult Delete(int id)
        {
            Category category = context.Categories.FirstOrDefault(c => c.ID == id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}