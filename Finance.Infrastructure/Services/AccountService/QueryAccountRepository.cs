using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using Finance.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Services.AccountService
{
    public class QueryAccountRepository : IQueryAccountRepository
    {
        public async Task<decimal> GetAccountUser(long accountId)
        {
            try
            {
                using var context = new ApplicationDbContext();

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
