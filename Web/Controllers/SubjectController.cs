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
                var subjects = _unitOfWork.SubjectRepository.GetAll();
                return Ok(subjects);
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
                var subject = await _unitOfWork.SubjectRepository.Get(Id);
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
        
        [HttpPost]
        [Route("api/subject")]
        public async Task<IActionResult> Add([FromBody]Subject subject)
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
        public async Task<IActionResult> Update([FromBody]Subject subject)
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
        [Route("api/subject/{Id:int}")]
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