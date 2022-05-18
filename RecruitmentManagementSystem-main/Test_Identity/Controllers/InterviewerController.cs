using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_Identity.Models;
using Test_Identity.ViewModels;

namespace Test_Identity.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class InterviewerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize(Roles = "Administrator, Recruiter")]
        // GET: TestInterviewerModels
        //public InterviewerController()
        //{

        //}
        public ActionResult Index()
        {
            return View(db.interviewerModels.ToList());
        }

        //[Authorize(Roles = "Administrator, Recruiter")]
        // GET: TestInterviewerModels/Details/5
        public ActionResult Details(int? id)
        {
            //InterviewerViewModel interviewerViewModel = new InterviewerViewModel()
            //{

            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewerModel interviewerModel = db.interviewerModels.Find(id);
            if (interviewerModel == null)
            {
                return HttpNotFound();
            }
            return View(interviewerModel);
        }

        //GET Create
        public ActionResult Create()
        {
            InterviewerModel inter = new InterviewerModel();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                inter.SkillCollection = db.skillModels.ToList();
            }
            return View(inter);
        }
        //Post
        [HttpPost]
        public ActionResult Create(InterviewerModel interviewerModel)
        {
            interviewerModel.SelectedSkillID = string.Join(",", interviewerModel.SelectedIDArray);
            //interviewerModel.SelectedSkillName = string.Join(",", interviewerModel.SelectedNameArray);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.interviewerModels.Add(interviewerModel);
                db.SaveChanges();

                InterviewerSkillIDModels interviewerSkillobj = new InterviewerSkillIDModels();
                interviewerSkillobj.InterviewerID = interviewerModel.ID;
                interviewerSkillobj.SkillID = interviewerModel.SelectedSkillID;
                db.interviewerSkill.Add(interviewerSkillobj);

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        //GET Edit
        public ActionResult Edit(int id = 0)
        {
            InterviewerModel inter = new InterviewerModel();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (id !=0)
                {
                    inter = db.interviewerModels.Where(x => x.ID == id).FirstOrDefault();
                }
                inter.SkillCollection = db.skillModels.ToList();
            }
            return View(inter);
        }
        //Post
        [HttpPost]
        public ActionResult Edit(InterviewerModel interviewerModel)
        {
            interviewerModel.SelectedSkillID = string.Join(",", interviewerModel.SelectedIDArray);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               if (interviewerModel.ID == 0)
                {
                    db.interviewerModels.Add(interviewerModel);
                }
                else
                {
                    db.Entry(interviewerModel).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Administrator, Recruiter")]
        // GET: TestInterviewerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewerModel interviewerModel = db.interviewerModels.Find(id);
            if (interviewerModel == null)
            {
                return HttpNotFound();
            }
            return View(interviewerModel);
        }

        // POST: TestInterviewerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterviewerModel interviewerModel = db.interviewerModels.Find(id);
            db.interviewerModels.Remove(interviewerModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}