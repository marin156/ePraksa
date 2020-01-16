using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IRatingTypeRepository
    {
        IEnumerable<RatingType> GetRatingTypes();
    }
}
