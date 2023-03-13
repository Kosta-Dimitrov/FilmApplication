using FilmApplication.Identity;
using FilmApplication.JWT;
using FilmApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IJWTManagerRepository JWTManager;
        private readonly IRegisterService registerService;

        public UserController(IRegisterService registerService,IJWTManagerRepository JWTManager)
        {
            this.registerService = registerService;
            this.JWTManager= JWTManager;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto model)
        {
            registerService.Register(model);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody]UserDto model)
        {
            Tokens token = JWTManager.Authenticate(model);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
}
