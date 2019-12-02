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
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/course")]
        public IActionResult GetAll()
        {
            try
            {
                var courses = _unitOfWork.CourseRepository.GetAll();
                return Ok(courses);
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
        [Route("api/course/{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var course = await _unitOfWork.CourseRepository.Get(Id);
                return Ok(course);
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
        [Route("api/course")]
        public async Task<IActionResult> Add([FromBody]Course course)
        {
            try
            {
                await _unitOfWork.CourseRepository.Add(course);
                return Ok(course);
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
        [Route("api/course")]
        public async Task<IActionResult> Update([FromBody]Course course)
        {
            try
            {
                await _unitOfWork.CourseRepository.Update(course);
                return Ok(course);
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
        [Route("api/course/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _unitOfWork.CourseRepository.Delete(Id);
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