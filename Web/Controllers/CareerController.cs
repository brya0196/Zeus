using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    public class CareerController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CareerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [Route("/api/career")]
        public IActionResult GetAll()
        {
            try
            {
                var careers = _unitOfWork.CareerRepository.GetAll();
                return Ok(careers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("/api/career/{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var career = await _unitOfWork.CareerRepository.Get(Id);
                return Ok(career);
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

        [HttpPost]
        [Route("/api/career")]
        public async Task<IActionResult> Add([FromBody] Career career)
        {
            try
            {
                await _unitOfWork.CareerRepository.Add(career);
                return Ok(career);
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
        [Route("/api/career")]
        public async Task<IActionResult> Update([FromBody] Career career)
        {
            try
            {
                await _unitOfWork.CareerRepository.Update(career);
                return Ok(career);
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
        [Route("/api/career/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.CareerRepository.Delete(Id);
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