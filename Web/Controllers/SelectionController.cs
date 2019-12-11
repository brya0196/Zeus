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
        public Subscription GetCurrentSubscription(int Id)
        {
            return _selectionService.GetCurrentSubscription(Id);
        }
        
        [HttpGet]
        [Route("api/selection/{Id:int}/{CareerId:int}")]
        public IEnumerable<Section> GetCurrentSelection(int Id, int CareerId)
        {
            return _selectionService.GetCurrentSelection(Id, CareerId);
        }
        
        [HttpPost]
        [Route("api/selection")]
        public IActionResult AddSubscription([FromBody] AddSubscriptionDTO addSubscriptionDto)
        {
            _selectionService.SubscribeStudent(addSubscriptionDto);
            return Ok();
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