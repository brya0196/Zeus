using System.Threading.Tasks;
using Core.DTO;
using Core.Interfaces;
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
        public async Task<IActionResult> Authentication([FromBody]AuthenticationDTO model)
        {
            var user = _userService.Authenticate(model);
            return Ok(user);
        }
    }
}