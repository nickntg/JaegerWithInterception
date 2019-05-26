using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IValuesRepository _values;

		public ValuesController(IValuesRepository valuesRepository)
		{
			_values = valuesRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return _values.GetValues();
		}
	}
}