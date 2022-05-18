using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Identity.Models
{
    public class InterviewerSkillIDModels
    {
        [Key]
        public int Id { get; set; }
        public int InterviewerID { get; set; }
        public string SkillID { get; set; }
    }
}