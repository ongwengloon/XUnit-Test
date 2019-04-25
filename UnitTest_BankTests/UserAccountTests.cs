using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTest_Bank002;

namespace UnitTest_BankTests
{
    [TestClass]
    public class UserAccountTests
    {
        public UserAccount UserAccount;

        [TestMethod]
        public void UserAccountGetAccountsTests()
        {
            //Arrange
            var Id = 1;
            //var mockAccounts = new List<UserAccount>
            //{
            //    new UserAccount(1, "Sky", 18),
            //    new UserAccount(2, "Jay Chow", 38),
            //    new UserAccount(3, "Captain Malaysia", 888)
            //};
            //var userAccountList = UserAccount.GetAccounts(Id);

            var mock = new Mock<IAccount>();
            //mock.Setup(_ => _.GetAccounts()).Returns(mockAccounts);


            var _userList = new List<IAccount>
            {
                new UserAccount(1, "Sky", 18),
                new UserAccount(2, "Jay Chow", 38),
                new UserAccount(3, "Captain Malaysia", 888)
            };

            mock.Setup(users => users.GetAccounts())
            .Returns<List<int>>(ids => _userList.ToList());

            var _user = _userList.FirstOrDefault();

            //var subject = new UserAccount(mock.Object);

            //Act
            //var accounts = subject..GetInvestmentAccounts(clientId, AccountType.Investment);

            //Assert
            Assert.IsNotNull(_user);
        }
    }
}
