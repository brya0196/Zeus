using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Generators;
using Data.Entities;

namespace Core.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User AddMatriculaToStudent(User user)
        {
            var lastUser = _unitOfWork.UserRepository.GetAll().Last();
            user.Matricula = MatriculaGenerator.Generator(lastUser.Matricula);
            return user;
        }
    }
}