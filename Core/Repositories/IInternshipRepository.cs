using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IInternshipRepository
    {
        IEnumerable<Internship> GetInternships();
        Internship GetInternship(int id);
    }
}
