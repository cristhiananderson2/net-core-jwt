using ProyectoNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoNetCore.Services;

namespace ProyectoNetCore.Services
{

    public class PersonService : IPersonService
    {

        public static List<Person> persons = new List<Person>();
        public List<Person> List()
        {
            return persons;
        }
        public Person Get(int id)
        {
            var person = persons.Find(x => x.Id == id);
            return person;
        }
        public void Save(Person obj)
        {
            obj.Id = persons.Count() + 1;
            persons.Add(obj);
        }

        public void Update(int id, Person obj)
        {
            var person = persons.Find(x => x.Id == id);
            person.Name = obj.Name;
            person.LastName = obj.LastName;
        }
        public void Delete(int id)
        {
            persons.RemoveAll(x => x.Id == id);
        }
    }
}
