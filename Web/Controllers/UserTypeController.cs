using System;
using System.Threading.Tasks;
using Core.Base;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    public class UserTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/usertype")]
        public IActionResult GetAll()
        {
            try
            {
                var userTypes = _unitOfWork.UserTypeRepository.GetAll();
                return Ok(userTypes);
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
        [Route("api/usertype/{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var userType = await _unitOfWork.UserTypeRepository.Get(Id);
                return Ok(userType);
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
        [Route("api/usertype")]
        public async Task<IActionResult> Add([FromBody]UserType userType)
        {
            try
            {
                await _unitOfWork.UserTypeRepository.Add(userType);
                return Ok(userType);
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
        [Route("api/usertype")]
        public async Task<IActionResult> Update([FromBody]UserType userType)
        {
            try
            {
                await _unitOfWork.UserTypeRepository.Update(userType);
                return Ok(userType);
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
        [Route("api/usertype/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.UserTypeRepository.Delete(Id);
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