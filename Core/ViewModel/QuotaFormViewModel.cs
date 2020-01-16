using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class QuotaFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [ValidDate]
        public string DateFrom { get; set; }

        [Required]
        [ValidDate]
        public string DateTo { get; set; }


        [Required]
        public string Amount { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Faculty { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }

        [Required]
        public int PracticeType { get; set; }
        public IEnumerable<PracticeType> PracticeTypes { get; set; }

        public string Heading { get; set; }

        public DateTime GetDateFrom()
        {
            return DateTime.Parse(DateFrom);
        }

        public DateTime GetDateTo()
        {
            return DateTime.Parse(DateTo);
        }
    }
}