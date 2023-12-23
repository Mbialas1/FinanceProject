using Finance.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Models
{
    public class AccountUser
    {
        public long Id { get; set; }
        [Required]
        public decimal AccountBalance { get; set; }
    }
}
