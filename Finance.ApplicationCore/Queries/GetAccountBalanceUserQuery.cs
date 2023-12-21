using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ApplicationCore.Queries
{
    public record GetAccountBalanceUserQuery : IRequest<AccountUser>
    {
        public long IdUser { get; init; }

        public GetAccountBalanceUserQuery(long idUser) => this.IdUser = idUser;
    }

    public class GetAccountBalanceUserQueryHandler : IRequestHandler<GetAccountBalanceUserQuery, AccountUser>
    {
        private readonly IQueryAccountRepository repository;
        private readonly ILogger<GetAccountBalanceUserQueryHandler> logger;

        public GetAccountBalanceUserQueryHandler(IQueryAccountRepository _queryAccountRepository, ILogger<GetAccountBalanceUserQueryHandler> _logger)
        {
            this.repository = _queryAccountRepository;
            this.logger = _logger;
        }

        public async Task<AccountUser> Handle(GetAccountBalanceUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                AccountUser result = await repository.GetAccountUser(request.IdUser);

                logger.LogInformation($"Account get for user {request.IdUser} !");

                return result;
            }
            catch(Exception ex) 
            {
                logger.LogError($"Problem in handler : {nameof(GetAccountBalanceUserQueryHandler)}. Details : {ex}");
                throw;
            }
        }
    }
}
