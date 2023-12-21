using Finance.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IMediator Mediator;
        //TODO Logi!
        public FinanceController(IMediator _mediator)
        {
            this.Mediator = _mediator;
        }

        [HttpPost("finance/addTransaction")]
        public async Task<IActionResult> AsddTransaction([FromBody] NewTransactionDTO newTransactionDTO)
        {
            return null;
        }

        [HttpGet("finance/getFinancesUser")]
        public async Task<ActionResult<IEnumerable<ActiveTransactionDTO>>> GetStoriesFinance()
        {
            //TODO : Add 2 tables active and deactvie transactions
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
