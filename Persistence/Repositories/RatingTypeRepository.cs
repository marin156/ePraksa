using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PracticeManagement.Persistence.Repositories
{
    public class RatingTypeRepository : IRatingTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public RatingType GetRatingType(int id)
        {
            return _context.RatingTypes
                .SingleOrDefault(d => d.Id == id);
        }
        public IEnumerable<RatingType> GetRatingTypes()
        {
            return _context.RatingTypes.ToList();
        }
    }
}
