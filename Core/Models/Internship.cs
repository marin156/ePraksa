using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PracticeManagement.Core.Models
{
    public class Internship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Criteria { get; set; }
        public int InternshipTypeID { get; set; }
        public int ProfesorID { get; set; }
        public int YearOfStudyID { get; set; }
        public int FacultyCourseID { get; set; }
        public FacultyCourse FacultyCourse { get; set; }
        public bool Activity { get; set; }
    }
}
