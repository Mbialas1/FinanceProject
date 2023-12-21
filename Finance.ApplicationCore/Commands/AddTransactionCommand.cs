using Finance.Domain.DTOs;
using Finance.Domain.Enums;
using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly ICommandFinanceRepository repository;
        private readonly ILogger<AddTransactionCommandHandler> logger;
        public AddTransactionCommandHandler(ICommandFinanceRepository _repository, ILogger<AddTransactionCommandHandler> _logger)
        {
            this.repository = _repository;
            this.logger = _logger;
        }

        public async Task<Transaction> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Transaction transaction = await repository.AddTranstacion(CreateNewTransaction(request.TransactionDTO));

                if (transaction is null)
                {
                    logger.LogError($"Can't add new transaction to base. Name of new transaction : {request.TransactionDTO.Name}");
                    throw new ArgumentNullException("Can't add new transaction to base");
                }

                logger.LogInformation($"Add new transaction id : {transaction.Id}");
                return transaction;
            }
            catch(Exception ex) 
            {
                logger.LogError($"Error in handler: {nameof(AddTransactionCommandHandler)}. Details : {ex}");
                throw;
            }
        }

        private Transaction CreateNewTransaction(NewTransactionDTO newTransactionDTO)
        {
            Transaction transaction = new Transaction()
            {
                Name = newTransactionDTO.Name,
                Description = newTransactionDTO.Description,
                CreatedDateTime = DateTime.UtcNow
            };

            if (!Enum.TryParse(newTransactionDTO.Currency, out CurrencyEnum currencyEnum))
            {
                logger.LogError($"Cannot parse currency : {newTransactionDTO.Currency} of task name : {transaction.Name}");
                return null;
            }
            else
                transaction.Currency = currencyEnum;

            if (!decimal.TryParse(newTransactionDTO.Amount, out decimal parseAmount))
            {
                logger.LogError($"Cannot parse amount : {newTransactionDTO.Amount} of task name : {transaction.Name}");
                return null;
            }
            else
                transaction.Amount = parseAmount;

            return transaction;
        }
    }
}
