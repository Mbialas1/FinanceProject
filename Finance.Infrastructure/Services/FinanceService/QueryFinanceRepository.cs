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
        private readonly ApplicationDbContext context;

        public QueryFinanceRepository(ApplicationDbContext _context)
        {
            this.context = _context;    
        }

        /// <summary>
        /// Get only 5 transactions for tests
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Transaction>> GetAllTransactions(int lastIndexID)
        {
            try
            {
                int userId = 1; //Test user 
                int pageSize = 5;
                int startIndex = lastIndexID == 1 ? 0 : lastIndexID;

                var transactions = await context.Transactions
                      .OrderBy(t => t.Id)
                      .Where(trans => trans.DeletedDateTime == null && trans.Id > startIndex && trans.UserId == userId)
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
