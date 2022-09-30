using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Test_Identity.Models;

namespace Test_Identity.ViewModels
{
    public class HistoryViewModel
    {
        public string Firstname { get; set; }
        public String Phone_no { get; set; }
        public string Email { get; set; }
        public string Experience { get; set; }
        public string Skill { get; set; }
        public float Current_CTC { get; set; }
        public float Expected_CTC { get; set; }
        public DateTime? Date_Time { get; set; }
        public string Current_address { get; set; }
        public List<InterviewRound2> interviewRound2s { get; set; }
    }
}