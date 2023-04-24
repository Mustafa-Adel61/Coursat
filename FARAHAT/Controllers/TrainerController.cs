using FARAHAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARAHAT.Controllers
{
    public class TrainerController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Trainer
        public ActionResult Index()
        {
            var s = context.Trainers.ToList();
            return View(s);
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int id)
        {
            var s = context.Trainers.FirstOrDefault(c => c.ID == id);
            return View(s);
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View (trainer);
                }
                else
                {
                    if (context.Trainers.Where(c => c.Email == trainer.Email).Any())
                    {
                        ViewBag.message = "This Trainer is Already Exist ";
                        return View(trainer);
                    }
                    else
                    {
                        
                        trainer.Creation_Date = DateTime.Now;
                        context.Trainers.Add(trainer);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Trainer");
                    }



                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            var s = context.Trainers.FirstOrDefault(c => c.ID == id);
            return View(s);
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(Trainer trainer)
        {
            try
            {
                Trainer trainer2 = context.Trainers.FirstOrDefault(c => c.Email == trainer.Email);
                if (trainer2 != null && trainer2.ID != trainer.ID)
                {
                    ViewBag.success = true;
                    ViewBag.message = "This Category is Already Exist ";
                    return View(trainer);
                }
                else
                {
                    ViewBag.message = $"Category {trainer.ID} is Updated successfully ";
                    Trainer trainer1 = context.Trainers.FirstOrDefault(c => c.ID == trainer.ID);
                    trainer1.Name = trainer.Name;
                    trainer1.Email = trainer.Email;
                    trainer1.Description = trainer.Description;
                    trainer1.Website = trainer.Website;
                    //خليت ال cration data زي مهو معمول 
                    context.SaveChanges();
                return View(trainer);
                }
            }
            catch(Exception ex)
            {
                return View (ex.Message);
            }
        }

        // GET: Trainer/Delete/5
        
        public ActionResult Delete(int id)
        {
          
               var s= context.Trainers.FirstOrDefault(c => c.ID == id);
                context.Trainers.Remove(s);
                context.SaveChanges();
                return RedirectToAction("Index", "Trainer");
           
        }
    }
}
