using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class StudentRatingDetailViewModel
    {
        public StudentRating StudentRating { get; set; }
        public Student Student { get; set; }
        public StudentInternship StudentInternship { get; set; }
        public Internship Internship { get; set; }
        public double AvgRating { get; set; }
        public FacultyCourse FacultyCourse { get; set; }
        public IEnumerable<RatingType> RatingTypes { get; set; }
    }
}
