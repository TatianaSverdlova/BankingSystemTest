using BankingSystemTest.Models;
using BankingSystemTest.Services.ManageAccount;
using BankingSystemTest.Services.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystemTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IManageAccountService _manageAccountService;
        private readonly ITransactionsService _transactionsService;

        public AccountsController(IManageAccountService manageAccountService, ITransactionsService transactionsService)
        {
            _manageAccountService = manageAccountService;
            _transactionsService = transactionsService;
        }

        [HttpPut("createAccount")]
        public BankAccount CreateAccount()
        {
            var result = _manageAccountService.CreateAccount();
            return result;
        }

        [HttpDelete("deleteAccount/{id}")]
        public string DeleteAccount(int id)
        {
            var result = _manageAccountService.DeleteAccount(id);
            return result;
        }

        [HttpGet("allAccounts")]
        public List<BankAccount> GetAllAccounts()
        {
            var result = _manageAccountService.GetAllAccounts();
            return result;
        }

        [HttpPost("deposit/{id}")]
        public string Deposit(int id, [FromQuery] decimal amount)
        {
            var result = _transactionsService.Deposit(amount, id);
            return result;
        }

        [HttpPost("withdraw/{id}")]
        public string Withdraw(int id, [FromQuery] decimal amount)
        {
            var result = _transactionsService.Withdraw(amount, id);
            return result;
        }
    }
}
