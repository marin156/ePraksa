using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace PracticeManagement.Core.Models
{
    public class StudentInternship
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int InternshipId { get; set; }
        public Internship Internship { get; set; }
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
