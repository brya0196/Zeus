using System;
using System.Threading.Tasks;
using Core.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class SubjectController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [Route("api/subject")]
        public IActionResult GetAll()
        {
            try
            {
                var users = _unitOfWork.SubjectRepository.GetAll();
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
        [Route("api/subject/{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var user = await _unitOfWork.SubjectRepository.Get(Id);
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
        [Route("api/subject")]
        public async Task<IActionResult> Add(Subject subject)
        {
            try
            {
                await _unitOfWork.SubjectRepository.Add(subject);
                return Ok(subject);
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
        [Route("api/subject")]
        public async Task<IActionResult> Update(Subject subject)
        {
            try
            {
                await _unitOfWork.SubjectRepository.Update(subject);
                return Ok(subject);
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
        [Route("api/subject")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.SubjectRepository.Delete(Id);
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