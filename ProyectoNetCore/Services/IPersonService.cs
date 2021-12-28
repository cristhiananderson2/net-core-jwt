using ProyectoNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoNetCore.Services
{
    public interface IPersonService
    {
        List<Person> List();
        Person Get(int id);
        void Save(Person obj);
        void Update(int id, Person obj);
        void Delete(int id);
    }
}
