using Finance.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
        private readonly IQueryFinanceRepository Repository;

        public GetFinancesForCurrentUserQueryHandler(IQueryFinanceRepository queryFinanceRepository)
        {
            this.Repository = queryFinanceRepository;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetFinancesForCurrentUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return null; //Pageowanie!!
            }
            catch
            {
                throw;
            }
        }
    }
}
