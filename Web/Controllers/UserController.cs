using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserController(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }
        
        [HttpGet]
        [Route("api/user")]
        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserRepository.GetAll().Select( x => x.WithoutPassword(x) );
        }
        
        [HttpGet]
        [Route("api/user/{Id:int}")]
        public async Task<User> GetById(int Id)
        {

            return await _unitOfWork.UserRepository.Get(Id);
        }
        
        [HttpPost]
        [Route("api/user")]
        public async Task<User> Add([FromBody]User user)
        {
            var userWithMatricula =  _userService.AddMatriculaToStudent(user);
            await _unitOfWork.UserRepository.Add(userWithMatricula);
            return await _unitOfWork.UserRepository.Get(userWithMatricula.Id);
        }
        
        [HttpPut]
        [Route("api/user")]
        public async Task<User> Update([FromBody]User user)
        {
            await _unitOfWork.UserRepository.Update(user);
            return await _unitOfWork.UserRepository.Get(user.Id);
        }
        
        [HttpDelete]
        [Route("api/user/{Id:int}")]
        public async Task<bool> Delete(int Id)
        {
            await _unitOfWork.UserRepository.Delete(Id);
            return true;
        }
        
    }
}