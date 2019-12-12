using System;
using System.Threading.Tasks;
using Core.Base;
using Core.DTO;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth")]
        public User Authentication([FromBody]AuthenticationDTO model)
        {
            return _userService.Authenticate(model);
        }
    }
}