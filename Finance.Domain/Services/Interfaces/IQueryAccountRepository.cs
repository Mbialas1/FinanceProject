﻿using Finance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Services.Interfaces
{
    public interface IQueryAccountRepository
    {
        Task<decimal> GetAccountUser(long accountId);
    }
}
