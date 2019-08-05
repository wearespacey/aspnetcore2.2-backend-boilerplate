using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models.V1;

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
        /// Gets all people.
        /// </summary>
        /// <returns>All available people.</returns>
        /// <response code="200">The successfully retrieved people.</response>
        [
            HttpGet,
            Produces("application/json"),
            ProducesResponseType(typeof(IEnumerable<Person>), 200)
        ]
        public IActionResult Get()
        {
            return Ok(People);
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
            Produces("application/json"),
            ProducesResponseType(typeof(Person), 200),
            ProducesResponseType(404)
        ]
        public IActionResult Get(int id)
        {
            var person = People[id];
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
            Produces("application/json"),
            ProducesResponseType(typeof(Person), 201),
            ProducesResponseType(400)
        ]
        public IActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            person.Id = People.Count;
            People.Add(person);
            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }
    }
}