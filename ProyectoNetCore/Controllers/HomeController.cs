using Microsoft.AspNetCore.Mvc;

namespace ProyectoNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
