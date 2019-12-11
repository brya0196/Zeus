using System;
using System.Collections.Generic;
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
        public IEnumerable<Section> GetAll()
        {
            return _unitOfWork.SectionRepository.GetAll();
        }

        [HttpGet]
        [Route("/api/section/{Id:int}")]
        public async Task<Section> Get(int Id)
        {
            return await _unitOfWork.SectionRepository.Get(Id);
        }

        [HttpPost]
        [Route("/api/section")]
        public async Task<Section> Add([FromBody] Section section)
        {
            await _unitOfWork.SectionRepository.Add(section);
            return await _unitOfWork.SectionRepository.Get(section.Id);
        }

        [HttpPut]
        [Route("/api/section")]
        public async Task<Section> Update([FromBody] Section section)
        {
            await _unitOfWork.SectionRepository.Update(section);
            return await _unitOfWork.SectionRepository.Get(section.Id);
        }

        [HttpDelete]
        [Route("/api/section/{Id:int}")]
        public async Task<bool> Delete(int Id)
        {
            await _unitOfWork.SectionRepository.Delete(Id);
            return true;
        }
    }
}