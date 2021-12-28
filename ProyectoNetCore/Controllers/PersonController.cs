using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoNetCore.Models;
using ProyectoNetCore.Services;
using System.Collections.Generic;

namespace ProyectoNetCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService service;

        public PersonController(IPersonService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Person> Get()
        {
            return service.List();
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        public Person Save(Person obj)
        {
            service.Save(obj);

            return obj;
        }

        [HttpPut("{id}")]
        public Person Update(int id, Person obj)
        {
            service.Update(id, obj);

            return obj;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }


    }
}
