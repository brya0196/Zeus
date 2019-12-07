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
    public class SectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("/api/section")]
        public IActionResult GetAll()
        {
            try
            {
                var sections = _unitOfWork.SectionRepository.GetAll();
                return Ok(sections);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("/api/section/{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var section = await _unitOfWork.SectionRepository.Get(Id);
                return Ok(section);
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
        [Route("/api/section")]
        public async Task<IActionResult> Add([FromBody] Section section)
        {
            try
            {
                await _unitOfWork.SectionRepository.Add(section);
                return Ok(section);
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
        [Route("/api/section")]
        public async Task<IActionResult> Update([FromBody] Section section)
        {
            try
            {
                await _unitOfWork.SectionRepository.Update(section);
                return Ok(section);
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
        [Route("/api/section/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.SectionRepository.Delete(Id);
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