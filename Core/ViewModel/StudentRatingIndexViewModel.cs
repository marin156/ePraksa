using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class StudentRatingIndexViewModel
    {
        public IEnumerable<StudentRating> StudentRatings { get; set; }

        public IEnumerable<StudentInternship> StudentInternships { get; set; }

        public IEnumerable<RatingType> RatingTypes { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }
    }
}
