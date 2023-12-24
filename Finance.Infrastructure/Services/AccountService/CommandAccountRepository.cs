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
        private readonly ApplicationDbContext context;
        public CommandAccountRepository(ApplicationDbContext _context)
        {
            this.context = _context;

        }
        public async Task UpdateAccountBalance(decimal amount)
        {
            try
            {
                long userId = 1;

                var account = await context.AccountUsers
                    .Where(acc => acc.Id == userId)
                    .FirstOrDefaultAsync();

                if (account == null)
                    throw new ArgumentNullException($"Cant find user with id {userId}");

                account.AccountBalance += amount;
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
