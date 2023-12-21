using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Services
{
    public class CommandFinanceRepository : ICommandFinanceRepository
    {
        public async Task<Transaction> AddTranstacion(Transaction newTransaction)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTranstacion(long idTransaction)
        {
            throw new NotImplementedException();
        }
    }
}
