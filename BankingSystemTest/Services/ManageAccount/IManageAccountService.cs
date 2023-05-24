using BankingSystemTest.Models;

namespace BankingSystemTest.Services.ManageAccount
{
    public interface IManageAccountService
    {
        BankAccount CreateAccount();
        string DeleteAccount(int accountId);
        List<BankAccount> GetAllAccounts();
    }
}
