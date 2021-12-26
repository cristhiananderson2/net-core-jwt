using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoNetCore.Models;
using System.Collections.Generic;

namespace ProyectoNetCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public Person Get()
        {
            return new Person(){ Id = 1, Name = "Cristhian", LastName = "Gómez" };
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
