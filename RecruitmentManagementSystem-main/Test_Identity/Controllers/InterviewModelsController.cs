using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_Identity.Models;
using System.Net.Mail;
using Test_Identity.ViewModels;

namespace Test_Identity.Controllers
{
    public class InterviewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoundInterviewModels
        public ActionResult Index()
        {
            InterviewModels model = new InterviewModels();
            var round = db.roundInterviews.ToList();
            foreach (var getCandId in round)
            {
                string candObj = db.candidatesModels.Where(x => x.Id == getCandId.CandidateId).Select(y => y.Firstname + " " + y.Lastname).FirstOrDefault().ToString();
                //getCandId.CandidateId = candObj;

                string interObj = db.interviewerModels.Where(x => x.ID == getCandId.InterviewerId).Select(y => y.Name).FirstOrDefault().ToString();
                //getCandId.InterviewerName = interObj;

                string jobObj = db.Jobs.Where(x => x.Id == getCandId.JobId).Select(y => y.JobDescription).FirstOrDefault().ToString();
                //getCandId.JobDiscription = jobObj;

            }
            List<InterviewModels> interviewModels = new List<InterviewModels>();
            List<InterviewVM> interviewVMObj = new List<InterviewVM>();
            foreach(InterviewModels interviewObj in interviewModels)
            {
                InterviewVM interviewVM = new InterviewVM();
                interviewVM.Id = interviewObj.Id;
                interviewVM.Round = interviewObj.Round;
                interviewVM.ModeOfInterview = interviewObj.ModeOfInterview;
                interviewVM.DateTime = interviewObj.DateTime;
                interviewVM.Comments = interviewObj.Comments;
            }
            return View("VmView",interviewVMObj);
          }


        // GET: RoundInterviewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewModels roundInterviewModels = db.roundInterviews.Find(id);
            if (roundInterviewModels == null)
            {
                return HttpNotFound();
            }
            return View(roundInterviewModels);
        }

        // GET: RoundInterviewModels/Create

        public ActionResult Create()
        {
            InterviewModels model = new InterviewModels();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.Candidate = db.candidatesModels.ToList();
                model.Interview = db.interviewerModels.ToList();
                model.job = db.Jobs.ToList();
            }
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InterviewModels roundInterviewModels)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var round = db.roundInterviews.ToList();
                //foreach (var getCandId in round)
                {
                    string candObj = db.candidatesModels.Where(x => x.Id == roundInterviewModels.CandidateId).Select(y => y.Email).FirstOrDefault().ToString();

                    //string interObj = db.interviewerModels.Where(x => x.ID == getCandId.InterviewerId).Select(y => y.Email).FirstOrDefault().ToString();

                    if (candObj == null)
                    {
                        if (roundInterviewModels.DateTime <= DateTime.Now)
                        {
                            db.roundInterviews.Add(roundInterviewModels);
                            //Email(roundInterviewModels);
                            db.SaveChanges();
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Enter valid Date Time.");
                            Response.Write("<script>alert('Enter valid Date Time.')</script>");
                            return Content(" ");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Already Scheduled.')</script>");
                        return Content(" ");
                    }
                }
                return RedirectToAction("Index");
            }

        }

        //For Time
        //public JsonResult IsTimeExist(DateTime dateTime)
        //{
        //    return Json(roundInterviewModels.DateTime <= DateTime.Now);
        //}

        public ActionResult Error()
        {
            string str = "Error Message";
            Response.Write("<script language=javascript>alert('" + str + "');</script>");
            return View(str);
        }

        // GET: RoundInterviewModels/Edit/5
        public ActionResult Edit(int id = 0)
        {
            InterviewModels model = new InterviewModels();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (id != 0)
                {
                    model = db.roundInterviews.Where(x => x.Id == id).FirstOrDefault();
                }
                model.Candidate = db.candidatesModels.ToList();
                model.Interview = db.interviewerModels.ToList();
                model.job = db.Jobs.ToList();
            }
            return View(model);
        }

        // POST: RoundInterviewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InterviewModels roundInterviewModels)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (roundInterviewModels.Id == 0)
                {
                    db.roundInterviews.Add(roundInterviewModels);
                }
                else
                {
                    db.Entry(roundInterviewModels).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: RoundInterviewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewModels roundInterviewModels = db.roundInterviews.Find(id);
            if (roundInterviewModels == null)
            {
                return HttpNotFound();
            }
            return View(roundInterviewModels);
        }

        // POST: RoundInterviewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterviewModels roundInterviewModels = db.roundInterviews.Find(id);
            db.roundInterviews.Remove(roundInterviewModels);
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

        // Email
        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Email(Test_Identity.Models.InterviewModels model)
        {

            int candId = model.CandidateId;
            string candObj = db.candidatesModels.Where(x => x.Id == candId).Select(y => y.Email).FirstOrDefault().ToString();

            int interId = model.InterviewerId;
            string interObj = db.interviewerModels.Where(x => x.ID == interId).Select(y => y.Email).FirstOrDefault().ToString();

            string form = $"{ candObj },{ interObj }";

            string Subject = "Interview Timing";

            string dt = Convert.ToString(model.DateTime);
            string Body = $"Your Interview timing is schedule on {dt}.";

            MailMessage mailMessage = new MailMessage("darkking7008@gmail.com", form);
            mailMessage.Subject = Subject;
            mailMessage.Body = Body;
            mailMessage.IsBodyHtml = false;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            NetworkCredential networkCredential = new NetworkCredential("darkking7008@gmail.com", "9693980959");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = networkCredential;
            smtpClient.Send(mailMessage);

            ViewBag.Message = "Mail Has Been send Successfully!";

            return View();
        }


    }
}
