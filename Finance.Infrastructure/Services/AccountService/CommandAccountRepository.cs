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
    public class CommandAccountRepository : ICommandAccountRepository
    {
        public CommandAccountRepository()
        {
        }
        public async Task UpdateAccountBalance(decimal amount)
        {
            try
            {
                long userId = 1; // Test user beacuse we dont have options/table for create new users.
                //using var contexte = context.;

                //var account = await context.AccountUsers
                //    .Where(acc => acc.Id == userId)
                //    .FirstOrDefaultAsync();

                //if (account == null)
                //    throw new ArgumentNullException($"Cant find user with id {userId}");

                //account.AccountBalance += amount;
                //await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
