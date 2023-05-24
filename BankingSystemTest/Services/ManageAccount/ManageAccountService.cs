using BankingSystemTest.Data;
using BankingSystemTest.Models;

namespace BankingSystemTest.Services.ManageAccount;

public class ManageAccountService : IManageAccountService
{
    public ManageAccountService()
    {
        
    }

    public BankAccount CreateAccount()
    {
        var account = new BankAccount();
        DataStorage.AddAccount(account);
        return account;
    }

    public string DeleteAccount(int accountId)
    {
        DataStorage.DeleteAccount(accountId);
        return $"Account {accountId} deleted successfully";
    }

    public List<BankAccount> GetAllAccounts()
    {
        var accounts = DataStorage.GetAccounts();
        return accounts;
    }
}