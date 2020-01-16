using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Repositories
{
    public interface IQuotaRepository
    {
        IEnumerable<Quota> GetQuotas();
        Quota GetQuota(int id);
        void Add(Quota quota);
        void Remove(Quota quota);
    }
}