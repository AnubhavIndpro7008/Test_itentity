using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test_Identity.Models
{
    public class InterviewViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Round of Interview")]
        public int Round { get; set; }

        [Display(Name = "Candidate Name ")]
        public int CandidateId { get; set; }
        [Display(Name = "Interviewer Name ")]
        public int InterviewerId { get; set; }

        [Display(Name = "Job Discription")]
        public string JobDiscription { get; set; }

        [Display(Name = "Mode of Interview")]
        public string ModeOfInterview { get; set; }

        [Required, Display(Name = "Date and time of Interview")]

        public DateTime DateTime { get; set; }
        public string Comments { get; set; }

        [ForeignKey("CandidateId")]
        public CandModels Candidate { get; set; }

        [ForeignKey("InterviewerId")]
        public InterviewerModel Interview { get; set; }

        [ForeignKey("JobId")]
        public Job Jobs { get; set; }
    }
}