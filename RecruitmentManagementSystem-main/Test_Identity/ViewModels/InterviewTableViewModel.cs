using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Identity.Models;

namespace Test_Identity.ViewModels
{
    public class InterviewTableViewModel
    {
        public List<CandModels> Cand { get; set; }
        public List<InterviewerModel> Interviewer { get; set; }
        public List<InterviewModels> InterviewDetails { get; set; }
        public List<Job> Jobs { get; set; }
        public List<InterviewRound2> interviewRound2s { get; set; }
    }
}