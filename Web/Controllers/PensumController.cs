using System;
using System.Collections.Generic;
using Core.Base;
using Data.Entities;
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
        public IEnumerable<Period> Pensum(int CareerId)
        {
            return _unitOfWork.PeriodRepository.Pensum(CareerId);
        }
    }
}