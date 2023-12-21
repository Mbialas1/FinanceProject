using Finance.Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private readonly ICommandFinanceRepository repository;
        private readonly ILogger<DeleteTransactionByIdCommandHandler> logger;

        public DeleteTransactionByIdCommandHandler(ICommandFinanceRepository commandFinanceRepository, ILogger<DeleteTransactionByIdCommandHandler> _logger)
        {
            this.repository = commandFinanceRepository;
            this.logger = _logger;
        }

        public async Task<bool> Handle (DeleteTransactionByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await repository.DeleteTranstacion(request.Id);

                if(result)
                    logger.LogInformation($"Sucessfull delete transaction by id : {request.Id}");

                return result;
            }
            catch(Exception ex) 
            {
                logger.LogError($"Problem in handler : {nameof(DeleteTransactionByIdCommandHandler)}. Details : {ex}");
                throw;
            }
        }
    }
}
