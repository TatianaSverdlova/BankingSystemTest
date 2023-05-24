namespace BankingSystemTest.Services.Transactions
{
    public interface ITransactionsService
    {
        string Deposit(decimal amount, int accountId);
        string Withdraw (decimal amount, int accountId);
    }
}
