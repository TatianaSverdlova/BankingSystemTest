using BankingSystemTest.Data;

namespace BankingSystemTest.Models
{
    public class BankAccount
    {
        private const decimal MinimumAccountBalance = 100m;
        public int Id { get; set; }
        public decimal Balance { get; set; } = MinimumAccountBalance;

        public BankAccount()
        {
            Id = DataStorage.GetAccounts().LastOrDefault()?.Id + 1 ?? 0;
        }
    }
}
