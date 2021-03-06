﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTest_Bank002;

namespace UnitTest_BankTests
{
    [TestClass]
    public class UserAccountTests : IDisposable
    {
        private UserAccountManager userAccountManager;
        private Mock<IUserAccountRepository> userAccountRepository;
        private Mock<IUserContactRepository> userContactRepository;

        [TestMethod]
        public void UserAccountGetAccountsTests()
        {
            //Setup
            userAccountRepository = new Mock<IUserAccountRepository>();
            userContactRepository = new Mock<IUserContactRepository>();

            //Mock Data
            var userList = new List<UserAccountModel>
            {
                new UserAccountModel(1, "Sky", 18),
                new UserAccountModel(2, "Jay Chow", 38),
                new UserAccountModel(3, "Captain Malaysia", 888)
            };
            var contact = new UserContactModel(1, "01755555555", "wl.ong@netium.net");

            //Setup Mock Data
            userAccountRepository.Setup(a => a.GetAccounts()).Returns(userList);
            userContactRepository.Setup(a => a.GetContacts(1)).Returns(contact);

            //Declare Manager
            userAccountManager = new UserAccountManager(userAccountRepository.Object, userContactRepository.Object);

            //Act
            const int id = 1;
            var result = userAccountManager.GetAccounts(id);

            //Expected Result
            var expectedResult = new UserAccountModel(1, "Sky", 18, contact);

            //Assert
            Assert.AreEqual(result.Name, expectedResult.Name);
            Assert.AreEqual(result.Contact.Phone, expectedResult.Contact.Phone);
        }

        public void Dispose()
        {
            userAccountManager = null;
            userAccountRepository = null;
            userContactRepository = null;
        }
    }
}
