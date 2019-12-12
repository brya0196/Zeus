using Core.Base;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Test.Mock;
using Web.Controllers;

namespace Test.Repositories
{
    public class UserRepositoryTest
    {
        [Test]
        public void ShouldReturnAllUsers()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var userService = new Mock<IUserService>();

            var users = MockData.GetFakeUsers();
            unitOfWork.Setup(x => x.UserRepository.GetAll()).Returns(users);
            
            var userController = new UserController(unitOfWork.Object, userService.Object);
            var result = userController.GetAll();
            Assert.AreEqual(users, result);
        }
    }
}