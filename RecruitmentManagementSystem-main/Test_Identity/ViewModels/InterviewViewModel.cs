using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Identity.ViewModels
{
    public class InterviewViewModel
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