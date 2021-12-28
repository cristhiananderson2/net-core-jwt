using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProyectoNetCore.Models;
using ProyectoNetCore.Tools;
using System.Security.Claims;

namespace ProyectoNetCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly JWTConfig jwtConfig;

        public UserController(IOptions<JWTConfig> config)
        {
            this.jwtConfig = config.Value;
        }


        [AllowAnonymous]
        [HttpPost("auth")]
        public string Auth(User obj)
        {
            return TokenGenerator.CreateToken(obj, jwtConfig);
        }

        [HttpGet("info")]
        public IActionResult Info()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            return Ok(new { 
                Name = claims.FindFirst(ClaimTypes.Name).Value,
                NameIdentifier = claims.FindFirst(ClaimTypes.NameIdentifier).Value,
                Email = claims.FindFirst(ClaimTypes.Email).Value
            });
        }
    }
}
