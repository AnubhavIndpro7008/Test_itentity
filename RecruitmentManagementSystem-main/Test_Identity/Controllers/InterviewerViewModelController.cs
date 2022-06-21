//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Test_Identity.Models;
//using Test_Identity.ViewModels;

//namespace Test_Identity.Controllers
//{
//    public class InterviewerViewModelController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();
//        // GET: InterviewerViewModel
//        public ActionResult Index()
//        {a

//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(InterviewerViewModel jobskill)
//        {
//            if (ModelState.IsValid)
//            {
//                db.interviewerModels.Add(jobskill.JobData);
//                db.interviewerModels.Add(jobskill.SkillData);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(jobskill);
//        }
//    }
//}