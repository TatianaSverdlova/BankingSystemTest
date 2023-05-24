using BankingSystemTest.Data;
using BankingSystemTest.Models;
using BankingSystemTest.Services.Transactions;
using Moq;

namespace BankingSystemTest.Tests
{
    public class TransactionsServiceTests
    {
        private readonly ITransactionsService _service;
        private readonly int _accountId = 1;
        private readonly decimal _initialBalance = 1000m;

        public TransactionsServiceTests()
        {
            var mockTransactionValidator = new Mock<ITransactionValidator>();
            _service = new TransactionsService(mockTransactionValidator.Object);
            SetUp();
        }

        private void SetUp()
        {
            DataStorage.AddAccount(new BankAccount { Id = _accountId, Balance = _initialBalance });
        }

        [Fact]
        public void Deposit_ShouldIncreaseBalanceByAmount()
        {
            // Arrange
            var account = DataStorage.GetAccountById(_accountId);
            decimal amount = 100m;
            decimal expected = account.Balance + amount;

            // Act
            _service.Deposit(amount, _accountId);

            // Assert
            account = DataStorage.GetAccountById(_accountId);
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldDecreaseBalanceByAmount()
        {
            // Arrange
            var account = DataStorage.GetAccountById(_accountId);
            decimal amount = 100m;
            decimal expected = account.Balance - amount;

            // Act
            _service.Withdraw(amount, _accountId);

            // Assert
            account = DataStorage.GetAccountById(_accountId);
            Assert.Equal(expected, account.Balance);
        }
    }
}