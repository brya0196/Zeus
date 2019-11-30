using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Base;
using Core.DTO;
using Core.Helpers;
using Core.Interfaces;
using Data.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User AddMatriculaToStudent(User user)
        {
            var lastUser = _unitOfWork.UserRepository.GetAll().Last();
            user.Matricula = MatriculaHelper.Generator(lastUser.Matricula);
            return user;
        }

        public User Authenticate(AuthenticationDTO model)
        {
            model.Password = PasswordHelper.HashPassword(model.Password);
            var user = _unitOfWork.UserRepository.GetAll()
                .SingleOrDefault(u => (u.Matricula == model.EmailOrMatricula || u.Email == model.EmailOrMatricula) && u.Password == model.Password);
            
            if (user == null)
            {
                return null;
            }

            var userWithToken = GetUserWithToken(user);
            return userWithToken;
        }

        private User GetUserWithToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("MySecretWorld");
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()), 
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword(user);
        }
    }
}