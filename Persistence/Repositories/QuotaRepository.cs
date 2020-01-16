using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class QuotaRepository : IQuotaRepository
    {
        private readonly ApplicationDbContext _context;
        public QuotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Quota> GetQuotas()
        {
            return _context.Quotas
                //.Include(t => t.PracticeType)
                .ToList();
        }

        public Quota GetQuota(int id)
        {
            return _context.Quotas.Find(id);
        }

        public void Add(Quota quota)
        {
            _context.Quotas.Add(quota);
        }

        public void Remove(Quota quota)
        {
            _context.Quotas.Remove(quota);
        }
    }
}