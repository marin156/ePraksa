using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace PracticeManagement.Core.Models
{
    public class StudentRating
    {
        public int Id { get; set; }
        public int StudentInternshipId { get; set; }
        public StudentInternship StudentInternship { get; set; }
        public int RatingTypeId { get; set; }
        public RatingType RatingType { get; set; }
        public String Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
