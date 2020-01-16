using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
    }
}
