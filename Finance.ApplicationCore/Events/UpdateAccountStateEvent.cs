using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ApplicationCore.Events
{
    public class UpdateAccountStateEvent : INotification
    {
        public decimal AmountTransaction { get; }

        public UpdateAccountStateEvent(decimal amountTransaction)
        {
            this.AmountTransaction = amountTransaction;
        }
    }
}
