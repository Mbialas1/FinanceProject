using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.DTOs
{
    public class NewTransactionDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Curreny { get; set; }
    }
}
