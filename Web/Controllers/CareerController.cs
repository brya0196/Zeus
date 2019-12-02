using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
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
        [Route("/api/career/pensum/{Id:int}")]
        public IActionResult GetByIdCareer(int Id)
        {
            try
            {
                var pensum = _unitOfWork.CareerSubjectRepository.GetAll().Where(u => u.CareerId == Id);
                return Ok(pensum);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}