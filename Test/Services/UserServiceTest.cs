using System.Linq;
using Core.Base;
using Core.DTO;
using Core.Interfaces;
using Core.Repositories;
using Moq;
using NUnit.Framework;
using Test.Mock;
using Web.Controllers;

namespace Test.Services
{
    public class UserServiceTest
    {
        /// <summary>
        /// Este metodo asegura que el usuario sea autenticado mediante su matricula y contrasena
        /// </summary>
        [Test]
        public void ShouldAuthenticateAUserByMatricula()
        {
            // configuramos el test llamando los repositorios, controladores o servicios a usar
            var userService = new Mock<IUserService>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var users = MockData.GetFakeUsers();
            unitOfWork.Setup(x => x.UserRepository.GetAll()).Returns(users);

            // configuramos lo valores a ser retornados por el test
            var testUser = users.First();
            var authenticationDto = new AuthenticationDTO();
            authenticationDto.EmailOrMatricula = testUser.Matricula;
            authenticationDto.Password = testUser.Password;
            userService.Setup(x => x.Authenticate(authenticationDto)).Returns(users.First());

            // verifcamos que el retorno de datos sea lo configurado en el test
            var controller = new AuthenticationController(userService.Object);
            var result = controller.Authentication(authenticationDto);
            Assert.AreEqual(testUser, result);
        }
        
        /// <summary>
        /// Este metodo asegura que el usuario sea autenticado mediante su email y contrasena
        /// </summary>
        [Test]
        public void ShouldAuthenticateAUserByEmail()
        {
            var userService = new Mock<IUserService>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var users = MockData.GetFakeUsers();
            unitOfWork.Setup(x => x.UserRepository.GetAll()).Returns(users);

            
            var testUser = users.First();
            var authenticationDto = new AuthenticationDTO();
            authenticationDto.EmailOrMatricula = testUser.Email;
            authenticationDto.Password = testUser.Password;
            userService.Setup(x => x.Authenticate(authenticationDto)).Returns(users.First());


            var controller = new AuthenticationController(userService.Object);
            var result = controller.Authentication(authenticationDto);
            Assert.AreEqual(testUser, result);
        }
        
        /// <summary>
        /// Este metodo asegura que el usuario no sea autenticado mediante si su matricula o contrasena son errones
        /// </summary>
        [Test]
        public void ShouldReturnNullIfEmailOrMatriculaIsWrong()
        {
            var userService = new Mock<IUserService>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var users = MockData.GetFakeUsers();
            unitOfWork.Setup(x => x.UserRepository.GetAll()).Returns(users);

            
            var testUser = users.First();
            var authenticationDto = new AuthenticationDTO();
            authenticationDto.EmailOrMatricula = "AWrongMatricula";
            authenticationDto.Password = testUser.Password;


            var controller = new AuthenticationController(userService.Object);
            var result = controller.Authentication(authenticationDto);
            Assert.Null(result);
        }
    }
}