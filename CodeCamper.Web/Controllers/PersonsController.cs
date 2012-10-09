﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Web.Controllers
{
    public class PersonsController : ApiControllerBase
    {
        public PersonsController(ICodeCamperUow uow)
        {
            Uow = uow;
        }

        // GET /api/persons
        public IEnumerable<Person> Get()
        {
            return Uow.Persons.GetAll()
                .OrderBy(p => p.FirstName);
        }

        // GET /api/persons/5
        public Person Get(int id)
        {
            var person = Uow.Persons.GetById(id);
            if (person != null) return person;
            throw new HttpResponseException(
                        new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Update an existing person
        // PUT /api/persons/
        public HttpResponseMessage Put(Person person)
        {
            Uow.Persons.Update(person);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}