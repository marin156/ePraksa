using PracticeManagement.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class RatingTypeConfiguration : EntityTypeConfiguration<RatingType>
    {
        public RatingTypeConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.Value).IsRequired();
            Property(p => p.Description).IsRequired().HasMaxLength(50);
        }
    }
}
