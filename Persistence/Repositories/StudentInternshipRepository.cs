using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class StudentInternshipRepository : IStudentInternshipRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentInternshipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get single StudentInternship - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentInternship GetStudentInternship(int id)
        {
            return _context.StudentInternships
                .Include(i => i.Internship)
                .Include(s => s.Student)
                .Include(m => m.Mentor)
                .SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<StudentInternship> GetStudentInternships()
        {
            return _context.StudentInternships
                .Include(i => i.Internship)
                .Include(s => s.Student)
                .Include(m => m.Mentor)
                .ToList();
        }
    }
}
