using Finance.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Finance.Infrastructure.Services
{
    public class QueryFinanceRepository : IQueryFinanceRepository
    {
        public Task<IEnumerable<Transaction>> GetAllTransains(int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
