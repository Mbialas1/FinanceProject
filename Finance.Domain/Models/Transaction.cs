using Finance.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; } = null;
        public decimal Amount { get; set; }
        public CurrencyEnum Currency { get; set; }
    }
}
