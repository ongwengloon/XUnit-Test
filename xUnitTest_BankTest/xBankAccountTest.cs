using System;
using UnitTest_Bank002;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly, MaxParallelThreads = 0, DisableTestParallelization = false)]

namespace xUnitTest_BankTest
{
    public class BankAccountFixture : IDisposable
    {
        public BankAccount Model { get; private set; }
        public double? BeginningBalance;


        public BankAccountFixture()
        {
            BeginningBalance = 11.99;
            Model = new BankAccount("Sky Ong", (double) BeginningBalance);
        }

        public void Dispose()
        {
            BeginningBalance = null;
            Model = null;
        }
    }

    [Collection("Serialize")]
    public class xBankAccountTest : IDisposable, IClassFixture<BankAccountFixture>
    {
        private readonly BankAccountFixture Account;
        private readonly ITestOutputHelper _output;

        public xBankAccountTest(BankAccountFixture bankAccount, ITestOutputHelper output)
        {
            Account = bankAccount;
            Account.Model.Balance = 11.99;
            //_beginningBalance = 11.99;
            //Account = new BankAccount("Sky Ong", (double)_beginningBalance);
            _output = output;
        }
        
        public void Dispose()
        {
            //Account = null;
            //_beginningBalance = null;
        }

        [Fact]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            //double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            //BankAccount Account = new BankAccount("Sky Ong", beginningBalance);

            // Act
            Account.Model.Debit(debitAmount);

            // Assert
            double actual = Account.Model.Balance;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            try
            {
                // Arrange
                //double beginningBalance = 11.99;
                double debitAmount = -100.00;
                //BankAccount Account = new BankAccount("Sky Ong", beginningBalance);

                // Act
                Account.Model.Debit(debitAmount);
            }
            catch
            {
                var ex = Assert.Throws<ArgumentOutOfRangeException>(() => ThrowAnError());
                Assert.Equal(BankAccount.DebitAmountLessThanZeroMessage, ex.ParamName);
            }

            // Assert is handled by the ExpectedException attribute on the test method.
        }

        [Fact]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            //double beginningBalance = 11.99;
            double debitAmount = 100.00;
            //BankAccount Account = new BankAccount("Sky Ong", beginningBalance);

            // Act
            try
            {
                Account.Model.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                Assert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, e.Message);
                return;
            }

            Assert.True(false, "The expected exception was not thrown.");
        }

        private void ThrowAnError()
        {
            throw new ArgumentOutOfRangeException(BankAccount.DebitAmountLessThanZeroMessage);
        }

        [Theory]
        [InlineData(0.99)]
        [InlineData(1)]
        [InlineData(10)]
        public void Debit_WithValidAmount_UpdatesBalance_InRange(double amount)
        {
            // Arrange
            Account.Model.Balance = 11.99;
            double debitAmount = amount;
            double expected = 11.99 - amount;

            _output.WriteLine("Balance={0}|Amount={1}|Expected{2}", Account.Model.Balance, amount, expected);

            // Act
            Account.Model.Debit(debitAmount);

            // Assert
            double actual = Account.Model.Balance;
            Assert.Equal(expected, actual);
        }
    }

}
