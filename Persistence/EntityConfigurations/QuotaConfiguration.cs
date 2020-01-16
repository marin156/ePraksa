using PracticeManagement.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class QuotaConfiguration : EntityTypeConfiguration<Quota>
    {
        public QuotaConfiguration()
        {
            Property(p => p.Id).IsRequired();
            //Property(p => p.CompanyId).IsRequired();
            Property(p => p.CollegeId).IsRequired();
            Property(p => p.DateFrom).IsRequired();
            Property(p => p.DateTo).IsRequired();
            Property(p => p.Activated).IsRequired();
            Property(p => p.StudentAmount).IsRequired();
            Property(p => p.Description).IsRequired().HasMaxLength(255);
            Property(p => p.TypeId).IsRequired();
        }
    }
}