using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Identity.Models
{
    public class InterviewModels
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public int CandidateId { get; set; }
        public int InterviewerId { get; set; }
        public int JobId { get; set; }
        public string ModeOfInterview { get; set; }
        public DateTime DateTime { get; set; }
        public string Comments { get; set; }

        [NotMapped]
        public IEnumerable<CandModels> Candidate { get; set; }

        [NotMapped]
        public IEnumerable<InterviewerModel> Interview { get; set; }
        [NotMapped]
        public IEnumerable<Job> job { get; set; }

    }

    public class InterviewVM
    {
        public int Id { get; set; }
        [Display(Name = "Round of Interview")]
        public int Round { get; set; }

        [Display(Name = "Candidate Name")]
        public string CandidateName { get; set; }

        [Display(Name = "Interviewer Name")]
        public string InterviewerName { get; set; }

        [Display(Name = "Job Discription")]
        public string JobDiscription { get; set; }

        [Display(Name = "Mode of Interview")]
        public string ModeOfInterview { get; set; }

        [Required, Display(Name = "Date and time of Interview")]

        public DateTime DateTime { get; set; }
        public string Comments { get; set; }
    }
}