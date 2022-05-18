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
    public class SkillModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SkillModels
        public ActionResult Index()
        {
            return View(db.skillModels.ToList());
        }

        // GET: SkillModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillModels skillModels = db.skillModels.Find(id);
            if (skillModels == null)
            {
                return HttpNotFound();
            }
            return View(skillModels);
        }

        // GET: SkillModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Skills")] SkillModels skillModels)
        {
            if (ModelState.IsValid)
            {
                db.skillModels.Add(skillModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skillModels);
        }

        // GET: SkillModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillModels skillModels = db.skillModels.Find(id);
            if (skillModels == null)
            {
                return HttpNotFound();
            }
            return View(skillModels);
        }

        // POST: SkillModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Skills")] SkillModels skillModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skillModels);
        }

        // GET: SkillModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillModels skillModels = db.skillModels.Find(id);
            if (skillModels == null)
            {
                return HttpNotFound();
            }
            return View(skillModels);
        }

        // POST: SkillModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkillModels skillModels = db.skillModels.Find(id);
            db.skillModels.Remove(skillModels);
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
