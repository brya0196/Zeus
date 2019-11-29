using System;
using System.Threading.Tasks;
using Core.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [Route("api/User")]
        public IActionResult GetAll()
        {
            try
            {
                var users = _unitOfWork.UserRepository.GetAll();
                return Ok(users);
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
        
        [HttpGet]
        [Route("api/User/{Id:int}")]
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
        [Route("api/User")]
        public async Task<IActionResult> Add(User user)
        {
            try
            {
                await _unitOfWork.UserRepository.Add(user);
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
        
        [HttpPut]
        [Route("api/User")]
        public async Task<IActionResult> Update(User user)
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
        [Route("api/User")]
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