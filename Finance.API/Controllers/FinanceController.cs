using Finance.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IMediator mediator;
        //TODO Logi!
        public FinanceController(IMediator _mediator)
        {
            this.mediator = _mediator;
        }

        [HttpPost("finance/addTransaction")]
        public async Task<IActionResult> AsddTransaction([FromBody] NewTransactionDTO newTransactionDTO)
        {
            return null;
        }

        [HttpGet("finance/getFinancesUser")]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetStoriesFinance()
        {
            return null;
        }

        //TODO Dodac przycisk delete
        [HttpDelete("finance/deleteTransactionById/{idFinance}")]
        public async Task<IActionResult> DeleteTransactionById(long idFinance)
        {
            return null;
        }

        //Tutaj event resourcing trzeba skorzystac :)
        [HttpGet("account/balance")]
        public async Task<ActionResult<long>> GetAccountBalanceUser()
        {
            return null;
        }

    }
}
