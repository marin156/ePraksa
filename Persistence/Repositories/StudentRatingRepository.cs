using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class StudentRatingRepository : IStudentRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get single StudentRating - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentRating GetStudentRating(int id)
        {
            return _context.StudentRatings
                .Include(s => s.StudentInternship)
                .Include(r => r.RatingType)
                .SingleOrDefault(d => d.Id == id);
        }

        public void Add(StudentRating StudentRating)
        {
            _context.StudentRatings.Add(StudentRating);
        }
        public void Remove(StudentRating StudentRating)
        {
            _context.StudentRatings.Remove(StudentRating);
        }

        public IEnumerable<StudentRating> GetStudentRatings()
        {
            return _context.StudentRatings
                .Include(s => s.StudentInternship)
                .Include(r => r.RatingType)
                .ToList();
        }
    }
}
