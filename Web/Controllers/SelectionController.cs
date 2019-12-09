using System.Collections.Generic;
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
            var selection = _selectionService.GetCurrentSelection(Id, CareerId);
            return Ok(selection);
        }
        
        [HttpPost]
        [Route("api/selection")]
        public IActionResult AddSubscription([FromBody] Subscription subscription,[FromBody] List<SubscriptionSection> subscriptionSections)
        {
           _selectionService.AddSubscription(subscription, subscriptionSections);
            return Ok(subscription);
        }
    }
}