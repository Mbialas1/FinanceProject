using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Finance.Domain.Services.Interfaces
{
    public interface IQueryFinanceRepository
    {
        Task<IEnumerable<Transaction>> GetAllTransains(int pageSize);
    }
}
