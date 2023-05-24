using BankingSystemTest.Data;

namespace BankingSystemTest.Services.Transactions;

class TransactionValidator : ITransactionValidator
{
    private const decimal MinimumAccountBalance = 100m;
    private const decimal DepositLimit = 10000m;
    private const float WithdrawLimitPercent = 0.9f;

    public TransactionValidator()
    {
        
    }

    public void ValidateRemainingAccountBalance(decimal balance, decimal amountToWithdraw)
    {
        var remainingBalance = balance - amountToWithdraw;
        if (remainingBalance < MinimumAccountBalance)
        {
            throw new InvalidOperationException("Account balance cannot be less than $100");
        }
    }

    public void ValidateRemainingTotalBalance(decimal amountToWithdraw)
    {
        var totalBalance = DataStorage.GetAccounts().Select(acc => acc.Balance).Sum();
        var withdrawalLimit = totalBalance * (decimal)WithdrawLimitPercent;
        if (amountToWithdraw > withdrawalLimit)
        {
            throw new InvalidOperationException("Withdrawal cannot be greater than 90% of total balance");
        }
    }

    public void ValidateDepositAmount(decimal depositAmount)
    {
        if (depositAmount > DepositLimit)
        {
            throw new InvalidOperationException("Single deposit amount cannot be greater than $10,000");
        }
    }
}