using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProyectoNetCore.Models;
using ProyectoNetCore.Tools;

namespace ProyectoNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly JWTConfig jwtConfig;

        public UserController(IOptions<JWTConfig> config)
        {
            this.jwtConfig = config.Value;
        }

        [HttpPost("auth")]
        public string Auth(User obj)
        {
            return TokenGenerator.CreateToken(obj, jwtConfig);
        }
    }
}
