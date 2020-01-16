using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class InternshipConfiguration : EntityTypeConfiguration<Internship>
    {
        public InternshipConfiguration()
        {
            Property(d => d.Id).IsRequired();
            Property(d => d.Name).IsRequired().HasMaxLength(50);
            Property(d => d.Description).IsRequired().HasMaxLength(250);
            Property(d => d.Plan).IsRequired().HasMaxLength(250);
            Property(d => d.Criteria).IsRequired().HasMaxLength(50);
            Property(d => d.InternshipTypeID).IsRequired();
            Property(d => d.ProfesorID).IsRequired();
            Property(d => d.YearOfStudyID).IsRequired();
            Property(d => d.FacultyCourseID).IsRequired();
            Property(d => d.Activity).IsRequired();
        }
    }
}
