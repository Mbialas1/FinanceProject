using Finance.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Finance.ApplicationCore.Commands
{
    public record AddTransactionCommand : IRequest<Transaction>
    {
        public NewTransactionDTO TransactionDTO { get; init; }

        public AddTransactionCommand(NewTransactionDTO TransactionDTO)
            => this.TransactionDTO = TransactionDTO;
    }

    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, Transaction>
    {
        private readonly ICommandFinanceRepository Repository;
        public AddTransactionCommandHandler(IFinanceRepository _repository)
        {
            this.Repository = _repository;
        }

        public async Task<Transaction> Handle(AddTransactionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
