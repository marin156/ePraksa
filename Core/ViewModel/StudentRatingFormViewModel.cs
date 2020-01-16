using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class StudentRatingFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Internship { get; set; }
        public IEnumerable<Internship> Internships { get; set; }

        [Required]
        public int StudentInternship { get; set; }
        public IEnumerable<StudentInternship> StudentInternships { get; set; }

        [Required]
        public int RatingType { get; set; }
        public IEnumerable<RatingType> RatingTypes { get; set; }

        public String Comment { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }

    }
}
