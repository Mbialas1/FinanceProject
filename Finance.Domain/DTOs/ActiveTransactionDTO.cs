using Finance.Domain.Enums;
using Finance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.DTOs
{
    public class ActiveTransactionDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }

        public ActiveTransactionDTO(Transaction transactionModel)
        {
            this.Id = transactionModel.Id;
            this.Name = transactionModel.Name;
            this.Description = transactionModel.Description;
            this.Amount = transactionModel.Amount.ToString();
            this.Currency = transactionModel.Currency.ToString();   
        }
    }
}
