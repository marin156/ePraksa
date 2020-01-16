using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PracticeManagement.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Name { get { return Firstname + " " + Lastname; } }
        public string Email { get; set; }
        public byte CityId { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public int FacultyCourseId { get; set; }
        public FacultyCourse FacultyCourse { get; set; }
        public int YearOfStudyId { get; set; }
        public string CV { get; set; }
        public int Active { get; set; }
    }
}
