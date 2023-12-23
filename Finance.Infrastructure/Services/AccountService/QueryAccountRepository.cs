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
        public async Task<decimal> GetAccountUser(long accountId)
        {
            try
            {
                return decimal.MaxValue;
                //using var context = new ApplicationDbContext(null);

                //var result = await context.AccountUsers
                //    .Where(user => user.Id == accountId)
                //    .Select(accountBalance => accountBalance.AccountBalance)
                //    .SingleOrDefaultAsync();

                //return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
