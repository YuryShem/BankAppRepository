using BankApp.Services;
using BankApp.Shared;
using BankApp.Shared.Exeptions;
using Microsoft.AspNetCore.Mvc;
using BankApp.Core;
using System.ComponentModel;

namespace BankApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(ILogger<AccountsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("UserAccounts")]
        public List<string> GetAccountList()
        {
            if (IntermediateData.person != null)
            {
                return OutputData.OutputUserAccountListForWebApi(IntermediateData.person.Id);
            }
            else
            {
                throw new LoginException();
            }
        }

        [HttpPost("SelectAccount")]
        public ActionResult SelectAccount(int accountNumber)
        {
            IntermediateData.accountId = AccountServices.SelectAccountForWebApi(IntermediateData.person.Id, accountNumber);
            IntermediateData.account = AccountServices.InitializeAccount(IntermediateData.accountId);

            return Ok($"You select {IntermediateData.account.AccountName} account");
        }

        [HttpGet("GetBalance")]
        public decimal GetAccountBalance()
        {
            return IntermediateData.account.Balance;
        }

        [HttpPost("AccountReplenishment")]
        public ActionResult ReplenishmentAccount(decimal amount)
        {
            try
            {
                Account.DepositForWebApi(IntermediateData.accountId, amount);

                return Ok("Carried out successfully.");
            }
            catch
            {
                throw new LoginException();
            }
        }

        [HttpPost("CashWithdrawal")]
        public ActionResult WithdrawalCash(decimal amount)
        {
            try
            {
                Account.DoWithdrawForWebApi(IntermediateData.account, amount);
                return Ok("Carried out successfully.");
            }
            catch
            {
                throw new LoginException();
            }
        }

        [HttpPost("TransferMoney")]
        public ActionResult TransferMoney(long iban, decimal amount)
        {
            try
            {
                Account.TransferMoneyForWebApi(IntermediateData.account.AccountId, iban, amount);
                return Ok("Carried out successfully.");
            }
            catch
            {
                throw new LoginException();
            }
        }

        [HttpPost("CreateNewAccount")]
        public ActionResult CreateNewAccount(string accountName, [Description(OutputData.accountTypeChoise)] int accountTypeId)
        {
            try
            {
                IAccount account = AccountServices.SelectIAccount(accountTypeId);
                IntermediateData.accountId = account.Create(accountName, IntermediateData.person.Id);
                IntermediateData.account = AccountServices.InitializeAccount(IntermediateData.accountId);

                return Ok("Carried out successfully.");
            }
            catch
            {
                throw new LoginException();
            }
        }

        [HttpPut("UpdateAccountName")]
        public ActionResult UpdateAccountName(string accountName)
        {
            try
            {
                Account.UpdateAccountNameFWA(IntermediateData.accountId, accountName);

                return Ok("Carried out successfully.");
            }
            catch
            {
                throw new LoginException();
            }
        }

        [HttpDelete("DeleteAccount")]
        public ActionResult DeleteAccount()
        {
            try
            {
                Account.RemoveFWA(IntermediateData.accountId);
                IntermediateData.accountId = 0;
                IntermediateData.account = null;

                return Ok("Carried out successfully.");
            }
            catch
            {
                throw new LoginException();
            }
        }

    }
}
