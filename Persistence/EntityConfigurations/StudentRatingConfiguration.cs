using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class StudentRatingConfiguration : EntityTypeConfiguration<StudentRating>
    {
        public StudentRatingConfiguration()
        {
            Property(d => d.Id).IsRequired();
            Property(d => d.StudentInternshipId).IsRequired();
            Property(d => d.RatingTypeId).IsRequired();
            Property(d => d.Comment);
            Property(d => d.Date).IsRequired();
        }
    }
}
