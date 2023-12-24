using Finance.ApplicationCore.Events;
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
    public class CommandAccountStateEventHandler : INotificationHandler<UpdateAccountStateEvent>
    {
        private readonly ICommandAccountRepository repository;
        private readonly ILogger<CommandAccountStateEventHandler> logger;
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        public CommandAccountStateEventHandler(ICommandAccountRepository _repository, ILogger<CommandAccountStateEventHandler> _logger)
        {
            this.repository = _repository;
            this.logger = _logger;
        }

        public async Task Handle(UpdateAccountStateEvent notification, CancellationToken cancellationToken)
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                await repository.UpdateAccountBalance(notification.AmountTransaction);

                logger.LogInformation($"Balanced account was update. Amount is {notification.AmountTransaction}. User id : 1 for test");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in handler: {nameof(CommandAccountStateEventHandler)}. Details : {ex}");
                throw;
            }
        }
    }
}
