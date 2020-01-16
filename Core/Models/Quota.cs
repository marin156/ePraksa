using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Models
{
    public class Quota
    {
        public int Id { get; set; }
        public int ComapnyId { get; set; }
        //public Company Company; firma tip

        public int CollegeId { get; set; }
        [ForeignKey("CollegeId")]
        public virtual Faculty Faculty { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Activated { get; set; }
        public int StudentAmount { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public PracticeType PracticeType;
    }
}