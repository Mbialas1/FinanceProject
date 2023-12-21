using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ApplicationCore.Commands
{
    public record DeleteTransactionByIdCommand : IRequest<bool>
    {
        public long Id { get; init; }

        public DeleteTransactionByIdCommand(long _id)
            => this.Id = _id;
    }

    public class DeleteTransactionByIdCommandHandler : IRequestHandler<DeleteTransactionByIdCommand, bool>
    {
        private readonly ICommandFinanceRepository Repository;

        public DeleteTransactionByIdCommandHandler(ICommandFinanceRepository commandFinanceRepository)
            => this.Repository = commandFinanceRepository; 

        public async Task<bool> Handle (DeleteTransactionByIdCommand request, bool result)
        {
            try
            {
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
