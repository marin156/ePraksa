using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Repositories
{
    public interface IStudentRatingRepository
    {
        IEnumerable<StudentRating> GetStudentRatings();
        StudentRating GetStudentRating(int id);
        void Add(StudentRating StudentRating);
        void Remove(StudentRating StudentRating);
    }
}
