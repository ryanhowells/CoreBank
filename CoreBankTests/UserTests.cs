using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccessLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoreBankTests
{
    [TestClass]
    public class UserTests
    {
        #region Initalise

        private readonly UserService _userService;
        private Mock<IRepository<User>> _userRepository;

        public UserTests()
        {
            _userRepository = new Mock<IRepository<User>>();
            _userService = new UserService(_userRepository.Object);
        }

        #endregion Initalise

        [TestMethod]
        public void UserTests_GetAll()
        {
            _userRepository.Setup(x => x.GetAll())
                .Returns(new List<User>{ new User { UserId = 1 } });

            var result = _userService.GetAll();

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void UserTests_GetById()
        {
            _userRepository.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(new User { UserId = 1 }); 

            var result = _userService.Get(x => x.UserId == 1);

            Assert.AreEqual(1, result.UserId);
        }

        [TestMethod]
        public void UserTests_Add()
        {
            var user = new User { UserId = 5 };
            _userRepository.Setup(x => x.Add(It.IsAny<User>()));
            _userService.Add(user);
            _userRepository.Verify(x => x.Add(It.IsAny<User>()), Times.Once());
        }

        [TestMethod]
        public void UserTests_AddRange()
        {
            var users = new List<User> { new User { UserId = 10 }, new User { UserId = 11 } };
            _userRepository.Setup(x => x.AddRange(It.IsAny<List<User>>()));
            _userService.AddRange(users);
            _userRepository.Verify(x => x.AddRange(It.IsAny<List<User>>()), Times.Once());
        }

        [TestMethod]
        public void UserTests_Remove()
        {
            var user = new User { UserId = 6 };
            _userRepository.Setup(x => x.Remove(It.IsAny<User>()));
            _userService.Remove(user);
            _userRepository.Verify(x => x.Remove(It.IsAny<User>()), Times.Once());
        }

        [TestMethod]
        public void UserTests_RemoveRange()
        {
            var users = new List<User> { new User { UserId = 12 }, new User { UserId = 13 } };
            _userRepository.Setup(x => x.RemoveRange(It.IsAny<List<User>>()));
            _userService.RemoveRange(users);
            _userRepository.Verify(x => x.RemoveRange(It.IsAny<List<User>>()), Times.Once());
        }
    }
}
