using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using Finance.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Services
{
    public class QueryFinanceRepository : IQueryFinanceRepository
    {
        /// <summary>
        /// Get only 5 transactions for tests
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Transaction>> GetAllTransactions(int pageNumber)
        {
            try
            {
                int pageSize = 5;
                int startIndex = pageNumber == 1 ? 0 : pageNumber * pageSize;

                using var context = new ApplicationDbContext();

                var transactions = await context.Transactions
                     .OrderBy(t => t.Id)
                     .Where(trans => trans.DeletedDateTime == null)
                     .Skip(startIndex)
                     .Take(pageSize)
                     .ToListAsync();

                return transactions;
            }
            catch
            {
                throw;
            }
        }
    }
}
