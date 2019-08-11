using System.Collections.Generic;
using System.Net;
using DAL.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Models.V1;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.V1
{
    /// <summary>
    /// Represents a RESTful people service.
    /// </summary>
    [
        ApiController,
        ApiVersion( "1.0-alpha" ),
        Route( "api/v{version:apiVersion}/[controller]" ),
        Produces("application/json")
    ]
    public class PeopleController : ControllerBase
    {
        private List<Person> People { get; set; }

        public PeopleController()
        {
            People = new List<Person>
            {
                new Person()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@somewhere.com"
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Smith",
                    Email = "bob.smith@somewhere.com"
                },
                new Person()
                {
                    Id = 3,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@somewhere.com"
                }
            };
        }

        /// <summary>
        /// Returns a certain number of people
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns>An array of people</returns>
        [
            HttpGet,
            SwaggerOperation(
                Summary = "Returns a certain number of people.",
                Description = "Requests a page of people not to load a lot of people on one request. The index and the page size are optional. The request returns an array of people based on the parameters."
            ),
            SwaggerResponse((int)HttpStatusCode.OK, "Returns an array of people.", typeof(IEnumerable<Person>)),
            SwaggerResponse((int)HttpStatusCode.BadRequest),
            SwaggerResponse((int)HttpStatusCode.NotFound)
        ]
        public /*async Task<*/IActionResult/*>*/ GetAll(int pageIndex = Constants.PAGE_INDEX, int pageSize = Constants.PAGE_SIZE)
        {
            int totalCount = People.Count; // change by DAL repository call

            IEnumerable<Person> entities = People; // change by DAL repository call
            if (entities == null) return NotFound();

            Request.HttpContext.Response.Headers.Add("X-TotalCount", totalCount.ToString());
            Request.HttpContext.Response.Headers.Add("X-PageIndex", pageIndex.ToString());
            Request.HttpContext.Response.Headers.Add("X-PageSize", pageSize.ToString());

            return Ok(entities);
        }

        /// <summary>
        /// Gets a single person.
        /// </summary>
        /// <param name="id">The requested person identifier.</param>
        /// <returns>The requested person.</returns>
        /// <response code="200">The person was successfully retrieved.</response>
        /// <response code="404">The person does not exist.</response>
        [
            HttpGet("{id:int}"),
            SwaggerOperation(
                Summary = "Gets a single person.",
                Description = "Gets a single person."
            ),
            SwaggerResponse((int)HttpStatusCode.OK, "The person was successfully retrieved.", typeof(Person)),
            SwaggerResponse((int)HttpStatusCode.NotFound, "The person does not exist.")
        ]
        public /*async Task<*/IActionResult/*>*/ GetById(int id)
        {
            var person = People[id]; // change by DAL repository call
            if (person == null) return NotFound();
            return Ok(person);
        }

        /// <summary>
        /// Places a new person.
        /// </summary>
        /// <param name="person">The person to place.</param>
        /// <returns>The created person.</returns>
        /// <response code="201">The person was successfully placed.</response>
        /// <response code="400">The person is invalid.</response>
        [
            HttpPost,
            SwaggerOperation(
                Summary = "Places a new person.",
                Description = "Adds a new person to the database."
            ),
            SwaggerResponse((int)HttpStatusCode.Created, "The person was successfully placed.", typeof(Person)),
            SwaggerResponse((int)HttpStatusCode.BadRequest, "The person is invalid.")
        ]
        public IActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            person.Id = People.Count; // remove when below line is edited
            People.Add(person); // change by DAL repository call
            return CreatedAtAction(nameof(GetById), new { person.Id }, person);
        }

        /// <summary>
        /// Edits a person.
        /// </summary>
        /// <param name="id">The person's identifier</param>
        /// <param name="person">The new person data</param>
        /// <returns>The edited person</returns>
        [
            HttpPut("{id:int}"),
            SwaggerOperation(
                Summary = "Edits a person based on their identifier.",
                Description = "Change the entity of a requested person based on the provided identifier."
            ),
            SwaggerResponse((int)HttpStatusCode.Accepted, "The person was successfully edited.", typeof(Person)),
            SwaggerResponse((int)HttpStatusCode.BadRequest),
            SwaggerResponse((int)HttpStatusCode.NotFound, "The person does not exist.")
        ]
        public /*async Task<*/IActionResult/*>*/ Put(int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Person entity = People[id]; // change by DAL repository call
            if (entity == null) return NotFound();

            person.Id = id; // delete when below line is edited
            entity = person; // change by DAL repository call
            return AcceptedAtAction(nameof(GetById), new {person.Id}, entity);
        }


        /// <summary>
        /// Deletes a person.
        /// </summary>
        /// <param name="id">The person's identifier</param>
        /// <returns>The deleted person</returns>
        [
            HttpDelete("{id:int}"),
            SwaggerOperation(
                Summary = "Deletes a person based on their identifier.",
                Description = "Deletes the entity of a requested person based on the provided identifier."
            ),
            SwaggerResponse((int)HttpStatusCode.Accepted, "The person was successfully deleted.", typeof(Person)),
            SwaggerResponse((int)HttpStatusCode.NotFound, "The person does not exist.")
        ]
        public /*async Task<*/IActionResult/*>*/ Delete(int id)
        {
            Person entity = People[id]; // change by DAL repository call
            if (entity == null) return NotFound();

            People.Remove(entity); // change by DAL repository call
            return Accepted(entity);
        }
    }
}