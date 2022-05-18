using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Identity.Models
{
    public class SkillModels
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Skills { get; set; }
    }
}