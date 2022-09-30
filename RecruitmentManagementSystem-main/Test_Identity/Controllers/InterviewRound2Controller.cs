using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_Identity.Models;
using Newtonsoft.Json;
//using PagedList.MVC;
using PagedList;
using Test_Identity.ViewModels;

namespace Test_Identity.Controllers
{
    public class InterviewRound2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InterviewRound2
        public ActionResult Index(string SearchBy, string Search, object SearchValue, int? i)
        {
            var candViewerDetails = db.Jobs.ToList();
            foreach (var getSkillId in candViewerDetails)
            {
                IEnumerable<int> fetchedSkillIds = getSkillId.SelectedSkillID.ToString().Split(',').Select(Int32.Parse);
                var getSkillName = db.skillModels.Where(x => fetchedSkillIds.Contains(x.ID))
                .Select(skillName => new { Name = skillName.Skills });

                string fetchSkillName = string.Join(",", getSkillName.Select(x => x.Name));
                getSkillId.SelectedSkillID = fetchSkillName;

            }
            if (SearchBy== "Firstname")
            {
                var interviewRound2s = db.interviewRound2s.Include(x => x.Candidate).Include(x => x.Interview).Include(x => x.Jobs).ToList();
                var model = db.interviewRound2s.Where(x=>x.Candidate.Firstname==Search || Search == null).ToList().ToPagedList(i ?? 1,3);
                return View(model);
            }
            else if (SearchBy == "Round")
            {
                var interviewRound2s = db.interviewRound2s.Include(x => x.Candidate).Include(x => x.Interview).Include(x => x.Jobs).ToList();
                var model = db.interviewRound2s.Where(x => x.Round.ToString() == Search || Search == null).ToList().ToPagedList(i ?? 1, 3);
                return View(model);
            }
            else /*if (SearchBy == "Results")*/
            {
                var interviewRound2s = db.interviewRound2s.Include(x => x.Candidate).Include(x => x.Interview).Include(x =>x.Jobs).ToList();
                var model = db.interviewRound2s.Where(x => x.Results.ToString() == Search || Search == null).ToList().ToPagedList(i ?? 1, 3);
                return View(model);
            }
            //else if (SearchBy == "SelectedSkillID")
            //{
            //    var roundInterview = db.roundInterviews.Include(x => x.Candidate).Include(x => x.Interview).Include(x => x.Jobs).ToList();
            //    var jobObject1 = db.Jobs.ToList();
            //    foreach (var getSkillId in jobObject1)
            //    {
            //        IEnumerable<int> fetchedSkillIds1 = getSkillId.SelectedSkillID.ToString().Split(',').Select(Int32.Parse);
            //        var getSkillName = db.skillModels.Where(x => fetchedSkillIds1.Contains(x.ID))
            //        .Select(skillName => new
            //        {
            //            skillName.Skills
            //        });

            //        string fetchSkillName = string.Join(",", getSkillName.Select(x => x.Skills));
            //        getSkillId.SelectedSkillID = fetchSkillName;
            //    }
            //    var filterData = db.interviewRound2s.Where(x => x.Jobs.SelectedSkillID.ToLower().Contains(SearchValue.ToLower())).ToList();
            //    return View(filterData);
            //}
            //else
            //{
            //    var interviewRound2s = db.interviewRound2s.Include(x => x.Candidate).Include(x => x.Interview).Include(x => x.Jobs).ToList();
            //    return View(db.interviewRound2s.ToList());
            //}
           
        }

        public ActionResult Index1(string SearchBy, string SearchValue, int? id)
        {
            //var jobObject0 = db.Jobs.ToList();
            //foreach (var getSkillId in jobObject0)
            //{
            //    IEnumerable<int> fetchedSkillIds1 = getSkillId.SelectedSkillID.ToString().Split(',').Select(Int32.Parse);
            //    var getSkillName = db.skillModels.Where(x => fetchedSkillIds1.Contains(x.ID))
            //    .Select(skillName => new
            //    {
            //        skillName.Skills
            //    });

            //    string fetchSkillName = string.Join(",", getSkillName.Select(x => x.Skills));
            //    getSkillId.SelectedSkillID = fetchSkillName;
            //}
            var roundInterviews = db.roundInterviews.Include(i => i.Candidate).Include(i => i.Interview).Include(i => i.Jobs).ToList();
            var jobObject = db.Jobs.ToList();
            InterviewModels interviewModels = db.roundInterviews.Find(id);
            if (SearchBy == "FirstName")
            {
                var model = db.roundInterviews.Where(x => x.Interview.Name.Contains(SearchValue) || SearchValue == null).ToList();
                return View(model);
            }
            else if (SearchBy == "SelectedSkillID")
            {
                var roundInterview = db.roundInterviews.Include(i => i.Candidate).Include(i => i.Interview).Include(i => i.Jobs).ToList();
                var jobObject1 = db.Jobs.ToList();
                foreach (var getSkillId in jobObject1)
                {
                    IEnumerable<int> fetchedSkillIds1 = getSkillId.SelectedSkillID.ToString().Split(',').Select(Int32.Parse);
                    var getSkillName = db.skillModels.Where(x => fetchedSkillIds1.Contains(x.ID))
                    .Select(skillName => new
                    {
                        skillName.Skills
                    });

                    string fetchSkillName = string.Join(",", getSkillName.Select(x => x.Skills));
                    getSkillId.SelectedSkillID = fetchSkillName;
                }
                var filterData = db.interviewRound2s.Where(x => x.Jobs.SelectedSkillID.ToLower().Contains(SearchValue.ToLower())).ToList();
                return View(filterData);

            }
            else if (SearchBy == "Results")
            {
                var model = db.interviewRound2s.Where(x => x.Results.ToString().Contains(SearchValue) || SearchValue == null).ToList();
                return View(model);
            }
            else
            {
                var model = db.interviewRound2s.Where(x => x.Date_Time.ToString().Contains(SearchValue) || SearchValue == null).ToList();
                return View(model);
            }
        }




        // GET: InterviewRound2/History
        public ActionResult History(int id)
        {
            HistoryViewModel CandHistory = new HistoryViewModel();
            var ExactCand = db.candidatesModels.Where(x => x.Id == id).FirstOrDefault();
            var ExactInterview = db.interviewRound2s.Where(x => x.CandidateId == id);
            CandHistory.Firstname = ExactCand.Firstname;
            CandHistory.Phone_no = ExactCand.Phone_no;
            CandHistory.Email = ExactCand.Email;
            CandHistory.Current_address = ExactCand.Current_address;
            CandHistory.Current_CTC = ExactCand.Current_CTC;
            CandHistory.Expected_CTC = ExactCand.Expected_CTC;
            CandHistory.Experience = ExactCand.Experience;
            CandHistory.Date_Time = ExactCand.Date_Time;
            CandHistory.interviewRound2s = ExactInterview.ToList();
            return View(CandHistory);





            //return View();
            //var CandModels = new List<CandModels>();
            //var interviewScheduler = new List<InterviewRound2>();

            //var interviewObj = db.interviewRound2s.Include(i => i.Candidate).Include(i => i.Interview).Include(i => i.Jobs).ToList();
            //var jobObject = db.Jobs.ToList();
            //foreach (var getSkillId in jobObject)
            //{
            //    IEnumerable<int> fetchedSkillIds = getSkillId.SelectedSkillID.ToString().Split(',').Select(Int32.Parse);
            //    var getSkillName = db.skillModels.Where(x => fetchedSkillIds.Contains(x.ID))
            //    .Select(skillName => new
            //    {
            //        skillName.Skills
            //    });

            //    string fetchSkillName = string.Join(",", getSkillName.Select(x => x.Skills));
            //    getSkillId.SelectedSkillID = fetchSkillName;
            //}
            //foreach (var intervewData in interviewObj)
            //{

            //    CandModels.Add(new CandModels { Firstname = intervewData.Candidate.Firstname, Phone_no=intervewData.Candidate.Phone_no, Email=intervewData.Candidate.Email, Current_address=intervewData.Candidate.Current_address, Current_CTC=intervewData.Candidate.Current_CTC, Expected_CTC=intervewData.Candidate.Expected_CTC, Skill=intervewData.Candidate.Skill, Experience=intervewData.Candidate.Experience });
            //    interviewScheduler.Add(new InterviewRound2 { Round = intervewData.Round, ModeOfInterview = intervewData.ModeOfInterview, Date_Time = intervewData.Date_Time, Comments = intervewData.Comments,   });


            //}

            //InterviewTableViewModel IVM = new InterviewTableViewModel
            //{

            //    Cand = CandModels,
            //    interviewRound2s = interviewScheduler
            //};

            //return View(IVM);
        }

        // GET: InterviewRound2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewRound2 interviewRound2 = db.interviewRound2s.Find(id);
            if (interviewRound2 == null)
            {
                return HttpNotFound();
            }
            return View(interviewRound2);
        }

        // GET: InterviewRound2/Create
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

        // POST: InterviewRound2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InterviewRound2 interviewRound2)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var round = db.interviewRound2s.ToList();
                //foreach (var getCandId in round)
                {
                    string candObj = db.candidatesModels.Where(x => x.Id == interviewRound2.CandidateId).Select(y => y.Email).FirstOrDefault().ToString();

                    //string interObj = db.interviewerModels.Where(x => x.ID == getCandId.InterviewerId).Select(y => y.Email).FirstOrDefault().ToString();

                    if (candObj != null)
                    {
                        //if (interviewRound2.Date_Time <= DateTime.Now)
                        //{
                        db.interviewRound2s.Add(interviewRound2);
                        db.SaveChanges();
                        //return RedirectToAction("Index");
                        //}
                        //else
                        //{
                        //    //ModelState.AddModelError("", "Enter valid Date Time.");
                        //    Response.Write("<script>alert('Enter valid Date Time.')</script>");
                        //    return Content(" ");
                        //}
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

        // GET: InterviewRound2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewRound2 interviewRound2 = db.interviewRound2s.Find(id);
            if (interviewRound2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateId = new SelectList(db.candidatesModels, "Id", "Firstname", interviewRound2.CandidateId);
            ViewBag.InterviewerId = new SelectList(db.interviewerModels, "ID", "Name", interviewRound2.InterviewerId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobName", interviewRound2.JobId);
            return View(interviewRound2);
        }

        // POST: InterviewRound2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Round,CandidateId,InterviewerId,JobId,ModeOfInterview,Date_Time,Comments,Results")] InterviewRound2 interviewRound2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interviewRound2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateId = new SelectList(db.candidatesModels, "Id", "Firstname", interviewRound2.CandidateId);
            ViewBag.InterviewerId = new SelectList(db.interviewerModels, "ID", "Name", interviewRound2.InterviewerId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobName", interviewRound2.JobId);
            return View(interviewRound2);
        }



        // GET: InterviewRound2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterviewRound2 interviewRound2 = db.interviewRound2s.Find(id);
            if (interviewRound2 == null)
            {
                return HttpNotFound();
            }
            return View(interviewRound2);
        }

        // POST: InterviewRound2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterviewRound2 interviewRound2 = db.interviewRound2s.Find(id);
            db.interviewRound2s.Remove(interviewRound2);
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


        //Search and Filter
        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {



            var interviewModels = db.interviewRound2s.Include(i => i.Candidate).Include(i => i.Interview).ToList();
            //var res = db.roundInterviews.Where(a => a.Interview.Name.ToLower().Contains(SearchValue) || a.Date_Time.ToString().Contains(SearchValue));
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
            List<InterviewRound2> interviewRound2 = new List<InterviewRound2>();
            if (SearchBy == "Id")
            {
                try
                {
                    int ID = Convert.ToInt32(SearchValue);
                    interviewRound2 = db.interviewRound2s.Where(x => x.Id == ID || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not an Id", SearchValue);
                }

                return Json(interviewRound2, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "Interview.Name")
            {
                interviewRound2 = db.interviewRound2s.Where(x => x.Candidate.Firstname.Contains(SearchValue) || SearchValue == null).ToList();
                return Json(interviewRound2, JsonRequestBehavior.AllowGet);
            }
            //else if (SearchBy == "Jobs.SelectedSkillID")
            //{
            //    interviewRound2 = db.interviewRound2s.Where(x => x.Round.Contains(SearchValue) || SearchValue == null).ToList();
            //    return Json(interviewRound2, JsonRequestBehavior.AllowGet);
            //}
            else
            {
                //interviewModels = db.roundInterviews.Where(x => x.Interview.Name.Contains(SearchValue) || x.Date_Time.ToString().Contains(SearchValue) || x.Results.ToString().Contains(SearchValue) || x.Jobs.SelectedSkillID.Contains(SearchValue) || SearchValue == null).ToList();
                //interviewModels = db.roundInterviews.Where(x => x.job.SelectedSkillID.Contains(SearchValue)).Where(x => x.Interview.Name.Contains(SearchValue)).Where(x => x.Date_Time.ToString().Contains(SearchValue)).ToList();
                return Json(interviewRound2, JsonRequestBehavior.AllowGet);
            }
        }
               
    }
}
