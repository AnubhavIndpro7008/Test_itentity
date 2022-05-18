using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_Identity.Models;

namespace Test_Identity.Controllers
{
    public class InterviewerSkillModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InterviewerSkillModels
        public ActionResult Index()
        {
            var interviewerSkillModels = db.interviewerSkillModels.Include(i => i.Interviewer).Include(i => i.Skill);
            return View(interviewerSkillModels.ToList());
        }

        // GET: InterviewerSkillModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewerSkillModels interviewerSkillModels = db.interviewerSkillModels.Find(id);
            if (interviewerSkillModels == null)
            {
                return HttpNotFound();
            }
            return View(interviewerSkillModels);
        }

        // GET: InterviewerSkillModels/Create
        public ActionResult Create()
        {
            ViewBag.InterviewerID = new SelectList(db.interviewerModels, "ID", "Name");
            ViewBag.SkillID = new SelectList(db.skillModels, "ID", "Skills");
            return View();
        }

        // POST: InterviewerSkillModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SkillID,InterviewerID")] InterviewerSkillModels interviewerSkillModels)
        {
            if (ModelState.IsValid)
            {
                db.interviewerSkillModels.Add(interviewerSkillModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InterviewerID = new SelectList(db.interviewerModels, "ID", "Name", interviewerSkillModels.InterviewerID);
            ViewBag.SkillID = new SelectList(db.skillModels, "ID", "Skills", interviewerSkillModels.SkillID);
            return View(interviewerSkillModels);
        }

        // GET: InterviewerSkillModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewerSkillModels interviewerSkillModels = db.interviewerSkillModels.Find(id);
            if (interviewerSkillModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.InterviewerID = new SelectList(db.interviewerModels, "ID", "Name", interviewerSkillModels.InterviewerID);
            ViewBag.SkillID = new SelectList(db.skillModels, "ID", "Skills", interviewerSkillModels.SkillID);
            return View(interviewerSkillModels);
        }

        // POST: InterviewerSkillModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SkillID,InterviewerID")] InterviewerSkillModels interviewerSkillModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interviewerSkillModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InterviewerID = new SelectList(db.interviewerModels, "ID", "Name", interviewerSkillModels.InterviewerID);
            ViewBag.SkillID = new SelectList(db.skillModels, "ID", "Skills", interviewerSkillModels.SkillID);
            return View(interviewerSkillModels);
        }

        // GET: InterviewerSkillModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewerSkillModels interviewerSkillModels = db.interviewerSkillModels.Find(id);
            if (interviewerSkillModels == null)
            {
                return HttpNotFound();
            }
            return View(interviewerSkillModels);
        }

        // POST: InterviewerSkillModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterviewerSkillModels interviewerSkillModels = db.interviewerSkillModels.Find(id);
            db.interviewerSkillModels.Remove(interviewerSkillModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
