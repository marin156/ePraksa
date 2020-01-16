using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class StudentInternshipConfiguration : EntityTypeConfiguration<StudentInternship>
    {
        public StudentInternshipConfiguration()
        {
            Property(d => d.Id).IsRequired();
            Property(d => d.StudentId).IsRequired();
            Property(d => d.InternshipId).IsRequired();
            Property(d => d.MentorId).IsRequired();
            Property(d => d.StartDate);
            Property(d => d.EndDate);
        }
    }
}
