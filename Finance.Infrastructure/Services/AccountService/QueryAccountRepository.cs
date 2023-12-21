using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Services.AccountService
{
    public class QueryAccountRepository : IQueryAccountRepository
    {
        public Task<AccountUser> GetAccountUser(long accountId)
        {
            throw new NotImplementedException();
        }
    }
}
