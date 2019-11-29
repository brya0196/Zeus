using System;
using System.Threading.Tasks;
using Core.Base;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/gender")]
        public IActionResult GetAll()
        {
            try
            {
                var genders = _unitOfWork.GenderRepository.GetAll();
                return Ok(genders);
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
        [Route("api/gender/{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var gender = await _unitOfWork.GenderRepository.Get(Id);
                return Ok(gender);
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
        [Route("api/gender")]
        public async Task<IActionResult> Add(Gender gender)
        {
            try
            {
                await _unitOfWork.GenderRepository.Add(gender);
                return Ok(gender);
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
        [Route("api/gender")]
        public async Task<IActionResult> Update(Gender gender)
        {
            try
            {
                await _unitOfWork.GenderRepository.Update(gender);
                return Ok(gender);
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
        [Route("api/gender")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.GenderRepository.Delete(Id);
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