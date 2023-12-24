using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using Finance.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Services.AccountService
{
    public class QueryAccountRepository : IQueryAccountRepository
    {
        private readonly ApplicationDbContext context;

        public QueryAccountRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task<decimal> GetAccountUser(long accountId)
        {
            try
            {
                var result = await context.AccountUsers
                    .Where(user => user.Id == accountId)
                    .Select(accountBalance => accountBalance.AccountBalance)
                    .SingleOrDefaultAsync();

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
