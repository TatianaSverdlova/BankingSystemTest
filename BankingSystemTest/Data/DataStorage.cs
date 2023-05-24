using BankingSystemTest.Models;

namespace BankingSystemTest.Data
{
    public static class DataStorage
    {
        public static List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

        //Create
        public static void AddAccount(BankAccount account)
        {
            BankAccounts.Add(account);
        }

        //Read
        public static BankAccount GetAccountById(int id)
        {
            var bankAccount = BankAccounts.FirstOrDefault(x => x.Id == id);
            return bankAccount;
        }

        public static List<BankAccount> GetAccounts()
        {
            return BankAccounts;
        }

        //Update
        public static void UpdateAccount(BankAccount account)
        {
            var bankAccount = BankAccounts.Find(x => x.Id == account.Id);
            bankAccount.Balance = account.Balance;
        }

        //Delete
        public static void DeleteAccount(int id)
        {
            var bankAccount = BankAccounts.Find(x => x.Id == id);
            BankAccounts.Remove(bankAccount);
        }
    }
}
