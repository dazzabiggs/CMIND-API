using KB.AUTH.Middleware.Models;
using KB.CMIND.API.CMDetails.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KB.CMIND.API.CMDetails.Controllers
{
    [Authorize]
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var client = _authService.Authenticate(model.ClientID, model.ClientSecret);

            if (client == null)
                return BadRequest(new { message = "Client ID or Secret is incorrect" });

            return Ok(client);
        }
    }
}
