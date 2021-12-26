using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoNetCore.Models;
using ProyectoNetCore.Tools;

namespace ProyectoNetCore.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {

        private readonly IOperationTransient operationTransient;
        private readonly IOperationScope operationScope;
        private readonly IOperationSingleton operationSingleton;
        private readonly Operation2 operation2;

        public OperationController(IOperationTransient operationTransient, IOperationScope operationScope, IOperationSingleton operationSingleton, Operation2 operation2)
        {
            this.operationTransient = operationTransient;
            this.operationScope = operationScope;
            this.operationSingleton = operationSingleton;
            this.operation2 = operation2;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new
            {
                Transient = operationTransient.Id,
                Scope = operationScope.Id,
                Singleton = operationSingleton.Id,
                Operation2 = operation2.Id
            });
        }

    }
}
