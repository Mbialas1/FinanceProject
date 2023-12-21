using Finance.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Models
{
    public class AccountUser
    {
        public long Id { get; set; }
        public decimal AccountBalance { get; set; }

        public AccountUserDTO ToDTO()
        {
            return new AccountUserDTO()
            {
                AccountBalance = AccountBalance.ToString()
            };
        }
    }
}
