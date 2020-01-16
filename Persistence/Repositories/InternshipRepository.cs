using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class InternshipRepository : IInternshipRepository
    {
        private readonly ApplicationDbContext _context;
        public InternshipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IEnumerable<Internship> GetInternship()
        //{
        //    return _context.Internships
        //        .ToList();
        //}

        /// <summary>
        /// Get single Internship - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Internship GetInternship(int id)
        {
            return _context.Internships
                .Include(f => f.FacultyCourse)
                .SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Internship> GetInternships()
        {
            return _context.Internships
                .ToList();
        }
    }
}
