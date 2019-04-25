using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest_Bank002;

//[assembly: Parallelize(Workers = 0, Scope = Microsoft.VisualStudio.TestTools.UnitTesting.ExecutionScope.MethodLevel)]

namespace BankTests
{
    [TestClass]
    public sealed class BankAccountTests //: IDisposable
    {
        private static double? _beginningBalance;
        public static BankAccount Account;

        /// <summary>
        /// Executes once before the test run. (Optional)
        /// </summary>
        /// <param name="context"></param>
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context){}

        /// <summary>
        /// Executes once after the test run. (Optional)
        /// </summary>
        [AssemblyCleanup]
        public static void AssemblyCleanup(){}

        /// <summary>
        /// Executes once for the test class. (Optional)
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            Account = new BankAccount("Sky Ong", 11.99);
        }

        /// <summary>
        /// Runs once after all tests in this class are executed. (Optional)
        /// Not guaranteed that it executes instantly after all tests from the class.
        /// </summary>
        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            _beginningBalance = null;
            Account = null;
        }

        /// <summary>
        /// Runs before each test. (Optional)
        /// </summary>
        [TestInitialize]
        public void Setup(){}

        /// <summary>
        /// Runs after each test. (Optional)
        /// </summary>
        [TestCleanup]
        public void TearDown(){}

        /* Constructor & IDisposable
        //You may use constructor as well, and inherit IDisposable
        public BankAccountTests()
        {
            //_beginningBalance = 11.99;
            Account = new BankAccount("Sky Ong", (double)_beginningBalance);
        }

        public void Dispose()
        {
            Account = null;
            _beginningBalance = null;
        }
        */


        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            //double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            //BankAccount account = new BankAccount("Sky Ong", beginningBalance);

            // Act
            Account.Debit(debitAmount);

            // Assert
            double actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            //double beginningBalance = 11.99;
            double debitAmount = -100.00;
            //BankAccount account = new BankAccount("Sky Ong", beginningBalance);

            // Act
            Account.Debit(debitAmount);

            // Assert is handled by the ExpectedException attribute on the test method.
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            //double beginningBalance = 11.99;
            double debitAmount = 100.00;
            //BankAccount account = new BankAccount("Sky Ong", beginningBalance);

            // Act
            try
            {
                Account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        [DataRow(0.99)]
        [DataRow(1)]
        [DataRow(10)]
        [DoNotParallelize]
        public void Debit_WithValidAmount_UpdatesBalance_InRange(double amount)
        {
            // Arrange
            Account.Balance = 11.99;
            double debitAmount = amount;
            double expected = 11.99 - amount;

            Console.WriteLine("Balance={0}|Amount={1}|Expected{2}", Account.Balance, amount, expected);
            // Act
            Account.Debit(debitAmount);

            // Assert
            double actual = Account.Balance;
            Assert.AreEqual(expected, actual);
        }
    }
}