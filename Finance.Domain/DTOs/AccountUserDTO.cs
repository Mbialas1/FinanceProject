using Finance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.DTOs
{
    public class AccountUserDTO
    {
        public string AccountBalance { get; set; }

        public AccountUserDTO(AccountUser accountUser)
        {
            this.AccountBalance = accountUser.AccountBalance.ToString();
        }
    }
}
