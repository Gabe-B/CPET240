using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Repositories; 

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PubsController : ControllerBase
	{
		//private readonly Repositories.AuthorRepoSQL auSQL;
		//private readonly Repositories.BookRepoSQL bSQL;

		public PubsController()// AuthorRepoSQL au, BookRepoSQL b)
		{
			Model.Author aux = null; 

			//auSQL = au;
			//bSQL = b;
		}

		#region Defaults
		// GET: api/<pubsController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<pubsController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<pubsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<pubsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<pubsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
		#endregion

		[HttpGet("helloworld")]
		public IActionResult HelloWorld()
		{
			return Ok("Hello World!");
		}
	}
}
