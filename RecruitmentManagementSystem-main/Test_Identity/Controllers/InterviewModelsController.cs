using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        public ActionResult Index1(string SearchBy, string Search)
        {
            var CandModels = new List<CandModels>();
            var Job = new List<Job>();
            var Interviewer = new List<InterviewerModel>();
            var interviewScheduler = new List<InterviewModels>();

            var interviewObj = db.roundInterviews.Include(i => i.Candidate).Include(i => i.Interview).Include(i => i.Jobs).ToList();
            var jobObject = db.Jobs.ToList();
            foreach (var getSkillId in jobObject)
            {
                IEnumerable<int> fetchedSkillIds = getSkillId.SelectedSkillID.ToString().Split(',').Select(Int32.Parse);
                var getSkillName = db.skillModels.Where(x => fetchedSkillIds.Contains(x.ID))
                .Select(skillName => new
                {
                    skillName.Skills
                });

                string fetchSkillName = string.Join(",", getSkillName.Select(x => x.Skills));
                getSkillId.SelectedSkillID = fetchSkillName;
            }
            foreach (var intervewData in interviewObj)
            {

                CandModels.Add(new CandModels { Firstname = intervewData.Candidate.Firstname });
                interviewScheduler.Add(new InterviewModels { Round = intervewData.Round, ModeOfInterview = intervewData.ModeOfInterview, DateTime = intervewData.DateTime, Comments = intervewData.Comments });
                Interviewer.Add(new InterviewerModel { Name = intervewData.Interview.Name });
                Job.Add(new Job { JobName = intervewData.Jobs.JobName, JobDescription = intervewData.Jobs.JobDescription, SelectedSkillID = intervewData.Jobs.SelectedSkillID });

            }

            InterviewTableViewModel IVM = new InterviewTableViewModel
            {

                Cand = CandModels,
                InterviewDetails = interviewScheduler,
                Interviewer = Interviewer,
                Jobs = Job
            };

            return View(IVM);
            //var candViewerDetails = db.Jobs.ToList();
            //foreach (var getSkillId in candViewerDetails)
            //{
            //    IEnumerable<int> fetchedSkillIds = getSkillId.SelectedSkillID.ToString().Split(',').Select(Int32.Parse);
            //    var getSkillName = db.skillModels.Where(x => fetchedSkillIds.Contains(x.ID))
            //    .Select(skillName => new { Name = skillName.Skills });

            //    string fetchSkillName = string.Join(",", getSkillName.Select(x => x.Name));
            //    getSkillId.SelectedSkillID = fetchSkillName;

            //}
            //var interviewRound2s = db.roundInterviews.Include(i => i.Candidate).Include(i => i.Interview).Include(i => i.Jobs).ToList();
            //if (SearchBy == "Firstname")
            //{            
            //    var model = db.roundInterviews.Where(x => x.Candidate.Firstname == Search || Search == null).ToList();
            //    return View(model);
            //}
            //else if (SearchBy == "Round")
            //{
            //    var model = db.roundInterviews.Where(x => x.Round.ToString() == Search || Search == null).ToList();
            //    return View(model);
            //}
            //else if (SearchBy == "Results")
            //{
            //    var interviewRound2s = db.interviewRound2s.Include(i => i.Candidate).Include(i => i.Interview).Include(i => i.Jobs).ToList();
            //    var model = db.interviewRound2s.Where(x => x.Results.ToString() == Search || Search == null).ToList();
            //    return View(model);
            //}
            //else
            //{
            //    var model = db.roundInterviews.Where(x => x.Candidate.Skill == Search || Search == null).ToList();
            //    return View(model);
            //}
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
            var cand = db.candidatesModels.ToList();
            ViewBag.cand = new SelectList(cand, "Id", "Firstname");
            var interviewer = db.interviewerModels.ToList();
            ViewBag.interviewer = new SelectList(interviewer, "ID", "Name");
            var job = db.Jobs.ToList();
            ViewBag.job = new SelectList(job, "Id", "JobDescription");
            return View();
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

                    //string candObj = db.candidatesModels.Where(x => x.Id == roundInterviewModels.CandidateId).Select(y => y.Email).FirstOrDefault().ToString();

                    //string interObj = db.interviewerModels.Where(x => x.ID == getCandId.InterviewerId).Select(y => y.Email).FirstOrDefault().ToString();

                    //if (candObj == null)
                    //{
                        //if (roundInterviewModels.DateTime <= DateTime.Now)
                        //{
                    db.roundInterviews.Add(roundInterviewModels);
                    //Email(roundInterviewModels);
                    db.SaveChanges();
                        //}
                        //else
                        //{
                        //    //ModelState.AddModelError("", "Enter valid Date Time.");
                        //    Response.Write("<script>alert('Enter valid Date Time.')</script>");
                        //    //TempData["message"] = "Update is disable , please wait till interview get over.";
                        //    return Content(" ");
                        //}
                    //}
                    //else
                    //{
                    //    Response.Write("<script>alert('Already Scheduled.')</script>");
                    //    return Content(" ");
                    //}
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewModels interviewModels = db.roundInterviews.Find(id);
            if (interviewModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateId = new SelectList(db.candidatesModels, "Id", "Firstname", interviewModels.CandidateId);
            ViewBag.InterviewerId = new SelectList(db.interviewerModels, "ID", "Name", interviewModels.InterviewerId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobName", interviewModels.JobId);
            return View(interviewModels);
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
