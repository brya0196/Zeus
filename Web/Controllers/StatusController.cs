using System;
using System.Threading.Tasks;
using Core.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/status")]
        public IActionResult GetAll()
        {
            try
            {
                var statuses = _unitOfWork.StatusRepository.GetAll();
                return Ok(statuses);
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
        [Route("api/status/{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var status = await _unitOfWork.StatusRepository.Get(Id);
                return Ok(status);
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
        [Route("api/status")]
        public async Task<IActionResult> Add(Status status)
        {
            try
            {
                await _unitOfWork.StatusRepository.Add(status);
                return Ok(status);
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
        [Route("api/status")]
        public async Task<IActionResult> Update(Status status)
        {
            try
            {
                await _unitOfWork.StatusRepository.Update(status);
                return Ok(status);
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
        [Route("api/status")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.StatusRepository.Delete(Id);
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