using System;
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
        public IActionResult GetAll()
        {
            try
            {
                var users = _unitOfWork.UserRepository.GetAll().Select( x => x.WithoutPassword(x) );
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [HttpGet]
        [Route("api/user/{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.Get(Id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
        
        [HttpPost]
        [Route("api/user")]
        public async Task<IActionResult> Add([FromBody]User user)
        {
            try
            {
                var userWithMatricula =  _userService.AddMatriculaToStudent(user);
                await _unitOfWork.UserRepository.Add(userWithMatricula);
                return Ok(user.WithoutPassword(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
        
        [HttpPut]
        [Route("api/user")]
        public async Task<IActionResult> Update([FromBody]User user)
        {
            try
            {
                await _unitOfWork.UserRepository.Update(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            finally
            {
                _unitOfWork.Dispose(); 
            }
        }
        
        [HttpDelete]
        [Route("api/user/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.UserRepository.Delete(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
        
    }
}