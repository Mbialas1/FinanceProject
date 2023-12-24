using Finance.ApplicationCore.Commands;
using Finance.ApplicationCore.Queries;
using Finance.Domain.DTOs;
using Finance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Finance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IMediator Mediator;
        private readonly ILogger<FinanceController> logger;
        private readonly IConfiguration configuration;
        public FinanceController(IMediator _mediator, ILogger<FinanceController> logger, IConfiguration _configuration)
        {
            this.Mediator = _mediator;
            this.logger = logger;
            this.configuration = _configuration;    
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("finance/getFinancesUser/{lastId}")]
        public async Task<ActionResult<IEnumerable<ActiveTransactionDTO>>> GetStoriesFinance(int lastId)
        {
            try
            {
                logger.LogInformation($"--- Start function {nameof(GetStoriesFinance)} ---");

                if (lastId < 1)
                    return BadRequest("Page number cannot be less than 1");

                var query = new GetFinancesForCurrentUserQuery(lastId);
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

        [Authorize]
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

        [Authorize]
        [HttpGet("account/balance")]
        public async Task<ActionResult<string>> GetAccountBalanceUser()
        {
            try
            {
                logger.LogInformation($"--- Start function {nameof(GetAccountBalanceUser)} ---");

                long userId = 1; // TODO : For test. Exist only one user.
                
                var query = new GetAccountBalanceUserQuery(userId);
                var result = await Mediator.Send(query);

                return result.ToString();
            }
            catch (Exception ex)
            {
                logger.LogError($" -- Exception in function {nameof(GetAccountBalanceUser)} more about : {ex} ---");
                return BadRequest();
            }
        }

        //Authorization
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, "TestUser")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

    }
}
