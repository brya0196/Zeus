using System;
using System.Collections.Generic;
using Core.DTO;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    [ApiController]
    public class SelectionController : Controller
    {
        private readonly ISelectionService _selectionService;

        public SelectionController(ISelectionService selectionService)
        {
            _selectionService = selectionService;
        }

        [HttpGet]
        [Route("api/selection/{Id:int}")]
        public IActionResult GetCurrentSubscription(int Id)
        {
            var subscription = _selectionService.GetCurrentSubscription(Id);
            return Ok(subscription);
        }
        
        [HttpGet]
        [Route("api/selection/{Id:int}/{CareerId:int}")]
        public IActionResult GetCurrentSelection(int Id, int CareerId)
        {
            try
            {
                var selection = _selectionService.GetCurrentSelection(Id, CareerId);
                return Ok(selection);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        [Route("api/selection")]
        public IActionResult AddSubscription([FromBody] AddSubscriptionDTO addSubscriptionDto)
        {
            try
            {
                _selectionService.SubscribeStudent(addSubscriptionDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("api/selection/{Id:int}")]
        public IActionResult DeleteSubscriptionSection(int Id)
        {
            _selectionService.DeleteSubscribeStudent(Id);
            return Ok();
        }
    }
}