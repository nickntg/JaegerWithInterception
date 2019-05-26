using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Client.Controllers
{
	[Route("[controller]/[action]")]
	public class IndexController : Controller
	{
		[HttpPost]
		public IActionResult DownloadValues()
		{
			var client = new RestClient("http://localhost:14702/");

			var request = new RestRequest("/api/values", DataFormat.Json);

			client.Execute(request, Method.GET);

			return Redirect("/");
		}
	}
}