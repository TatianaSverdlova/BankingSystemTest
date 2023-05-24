namespace BankingSystemTest.Services.Transactions
{
    public interface ITransactionValidator
    {
        void ValidateRemainingAccountBalance(decimal balance, decimal amountToWithdraw);
        void ValidateRemainingTotalBalance(decimal amountToWithdraw);
        void ValidateDepositAmount(decimal depositAmount);
    }
}
