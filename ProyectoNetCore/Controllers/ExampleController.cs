using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProyectoNetCore.Models;
using ProyectoNetCore.Tools;
using System.Collections.Generic;

namespace ProyectoNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public Person Get()
        {
            return new Person() { Id = 1, Name = "Cristhian", LastName = "Gómez" };
        }

        [HttpPost]
        public Person Save(Person obj)
        {
            return obj;
        }

        [HttpGet("{id}/lenguages")]
        public List<Language> GetLanguages(int id)
        {
            return new List<Language>()
            {
                new () { Id = 1, Name ="JAVA" },
                new () { Id = 1, Name ="PHP" },
                new () { Id = 1, Name ="JAVASCRIPT" }
            };
        }
    }
}
