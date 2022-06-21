using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Test_Identity.Migrations;

namespace Test_Identity.Models
{
    public class ModeOfInterviewModels
    {
        public int Id { get; set; }
        [Required, Display(Name ="Mode of Interviewer")]
        public string Mode { get; set; }
    }
}