using AssignmentXCompany.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentXCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult CreateToken()
        {
            var token = _authService.CreateToken();
            return Ok(token);
        }

        [HttpGet]
        public IActionResult ThrowException()
        {
            throw new Exception("for test GlobalErrorHandlerMiddleware");
        }
    }
}
