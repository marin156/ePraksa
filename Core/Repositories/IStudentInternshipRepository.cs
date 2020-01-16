using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IStudentInternshipRepository
    {
        IEnumerable<StudentInternship> GetStudentInternships();
        StudentInternship GetStudentInternship(int id);
    }
}
