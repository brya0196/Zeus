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
    public class PeriodController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public PeriodController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("/api/period")]
        public IActionResult GetAll()
        {
            try
            {
                var careers = _unitOfWork.PeriodRepository.GetAll();
                return Ok(careers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("/api/period/{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var career = await _unitOfWork.PeriodRepository.Get(Id);
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
        [Route("/api/period")]
        public async Task<IActionResult> Add([FromBody] Period period)
        {
            try
            {
                await _unitOfWork.PeriodRepository.Add(period);
                return Ok(period);
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
        [Route("/api/period")]
        public async Task<IActionResult> Update([FromBody] Period period)
        {
            try
            {
                await _unitOfWork.PeriodRepository.Update(period);
                return Ok(period);
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
        [Route("/api/period/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.PeriodRepository.Delete(Id);
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