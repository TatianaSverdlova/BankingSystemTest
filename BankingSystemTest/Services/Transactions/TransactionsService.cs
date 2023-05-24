using BankingSystemTest.Data;

namespace BankingSystemTest.Services.Transactions;

public class TransactionsService : ITransactionsService
{
    private readonly ITransactionValidator _transactionValidator;

    public TransactionsService(ITransactionValidator transactionValidator)
    {
        _transactionValidator = transactionValidator;
    }

    public string Deposit(decimal amount, int accountId)
    {
        _transactionValidator.ValidateDepositAmount(amount);

        var accountToUpdate = DataStorage.GetAccountById(accountId);
        accountToUpdate.Balance += amount;

        DataStorage.UpdateAccount(accountToUpdate);

        return $"Deposit of ${amount} successfully deposit to account {accountId}";
    }

    public string Withdraw(decimal amount, int accountId)
    {
        var account = DataStorage.GetAccountById(accountId);

        _transactionValidator.ValidateRemainingAccountBalance(account.Balance, amount);
        _transactionValidator.ValidateRemainingTotalBalance(amount);

        account.Balance -= amount;
        DataStorage.UpdateAccount(account);

        return $"Account {accountId} was withdrawn by ${amount}";
    }
}