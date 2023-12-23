using Finance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure.EntityFramework
{
    public interface IApplicationDbContext
    {
        DbSet<Transaction> Transactions { get; set; }
        DbSet<AccountUser> AccountUsers { get; set; }
    }
}
