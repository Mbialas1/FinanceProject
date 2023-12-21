using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using Finance.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.Services
{
    public class CommandFinanceRepository : ICommandFinanceRepository
    {
        public async Task<Transaction> AddTranstacion(Transaction newTransaction)
        {
            try
            {
                using var context = new ApplicationDbContext();

                await context.Transactions.AddAsync(newTransaction);
                await context.SaveChangesAsync();

                return newTransaction;
            }
            catch (DbUpdateException ex)
            {
                if (ex.GetBaseException() is SqlException sqlException &&
                    sqlException?.Number == 2601)
                    throw new Exception($"Name of transaction : {newTransaction.Name} is exist in db.");

                throw;
            }
        }

        public async Task<bool> DeleteTranstacion(long idTransaction)
        {
            //TODO Create another table for deleteTransactions and remove here from current table
            try
            {
                using var context = new ApplicationDbContext();

                var transaction = await context.Transactions.FindAsync(idTransaction);
                if (transaction is null)
                    return false;

                transaction.DeletedDateTime = DateTime.UtcNow;
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
