using Finance.ApplicationCore.Commands;
using Finance.Domain.DTOs;
using Finance.Domain.Models;
using Finance.Domain.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ApplicationCore.Queries
{
    public record GetFinancesForCurrentUserQuery : IRequest<IEnumerable<Transaction>>
    {
        public int page { get; init; }

        public GetFinancesForCurrentUserQuery(int _page)
            => this.page = _page;
    }

    public class GetFinancesForCurrentUserQueryHandler : IRequestHandler<GetFinancesForCurrentUserQuery, IEnumerable<Transaction>>
    {
        private readonly IQueryFinanceRepository repository;
        private readonly ILogger<GetFinancesForCurrentUserQueryHandler> logger;
        public GetFinancesForCurrentUserQueryHandler(IQueryFinanceRepository queryFinanceRepository, ILogger<GetFinancesForCurrentUserQueryHandler> _logger)
        {
            this.repository = queryFinanceRepository;
            this.logger = _logger;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetFinancesForCurrentUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Transaction> transactions = await repository.GetAllTransains(request.page);

                logger.LogInformation("Transactions list is ready!");

                return transactions; 
            }
            catch(Exception ex)
            {
                logger.LogError($"Problem in handler : {nameof(GetFinancesForCurrentUserQueryHandler)}. Details : {ex}");
                throw;
            }
        }
    }
}
