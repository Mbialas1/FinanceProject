using Finance.ApplicationCore.Commands;
using Finance.ApplicationCore.Queries;
using Finance.Domain.DTOs;
using Finance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly ILogger<FinanceController> logger;
        public FinanceController(IMediator _mediator, ILogger<FinanceController> logger)
        {
            this.Mediator = _mediator;
            this.logger = logger;
        }

        [HttpPost("finance/addTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] NewTransactionDTO newTransactionDTO)
        {
            try
            {
                logger.LogInformation($"--- Start function {nameof(AddTransaction)} ---");

                if (string.IsNullOrEmpty(newTransactionDTO.Name))
                    return BadRequest("Name cannot be empty or null!");

                var command = new AddTransactionCommand(newTransactionDTO);
                var result = await Mediator.Send(command);

                return Ok(result.Id);
            }
            catch (Exception ex)
            {
                logger.LogError($" -- Exception in function {nameof(AddTransaction)} more about : {ex} ---");
                return BadRequest();
            }
        }

        [HttpGet("finance/getFinancesUser/{pageNumber}")]
        public async Task<ActionResult<IEnumerable<ActiveTransactionDTO>>> GetStoriesFinance(int pageNumber)
        {
            try
            {
                logger.LogInformation($"--- Start function {nameof(GetStoriesFinance)} ---");

                if (pageNumber < 1)
                    return BadRequest("Page number cannot be less than 1");

                var query = new GetFinancesForCurrentUserQuery(pageNumber);
                var result = await Mediator.Send(query);

                IList<ActiveTransactionDTO> activeTransactions = new List<ActiveTransactionDTO>();
                foreach (Transaction transaction in result)
                    activeTransactions.Add(new ActiveTransactionDTO(transaction));

                return Ok(activeTransactions);
            }
            catch (Exception ex)
            {
                logger.LogError($" -- Exception in function {nameof(GetStoriesFinance)} more about : {ex} ---");
                return BadRequest();
            }
        }

        [HttpDelete("finance/deleteTransactionById/{idFinance}")]
        public async Task<IActionResult> DeleteTransactionById(long idFinance)
        {
            try
            {
                logger.LogInformation($"--- Start function {nameof(DeleteTransactionById)} ---");

                if (idFinance < 1)
                    return BadRequest("ID finance cannot be less than 1");

                var command = new DeleteTransactionByIdCommand(idFinance);
                var result = await Mediator.Send(command);

                if (result)
                    return Ok();
                else
                    return BadRequest("Operation failed!");
            }
            catch (Exception ex)
            {
                logger.LogError($" -- Exception in function {nameof(DeleteTransactionById)} more about : {ex} ---");
                return BadRequest();
            }
        }

        [HttpGet("account/balance")]
        public async Task<ActionResult<long>> GetAccountBalanceUser()
        {
            try
            {
                logger.LogInformation($"--- Start function {nameof(GetAccountBalanceUser)} ---");

                //TODO 

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError($" -- Exception in function {nameof(GetAccountBalanceUser)} more about : {ex} ---");
                return BadRequest();
            }
        }

    }
}
