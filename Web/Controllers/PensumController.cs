using System;
using Core.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    public class PensumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PensumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/pensum/{CareerId:int}")]
        public IActionResult Pensum(int CareerId)
        {
            try
            {
                var pensums = _unitOfWork.PeriodRepository.Pensum(CareerId);
                return Ok(pensums);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}