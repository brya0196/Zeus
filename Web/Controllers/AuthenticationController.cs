using System;
using System.Threading.Tasks;
using Core.Base;
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
        private readonly  IUnitOfWork _unitOfWork;

        public AuthenticationController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth")]
        public IActionResult Authentication([FromBody]AuthenticationDTO model)
        {
            try
            {
                var user = _userService.Authenticate(model);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}