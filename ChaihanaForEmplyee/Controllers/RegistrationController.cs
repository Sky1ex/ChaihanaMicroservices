using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Repository.Default;

namespace ChaihanaForEmplyee.Controllers
{
	public class RegistrationController : Controller
	{
		private readonly ILogger<RegistrationController> _logger;


		public RegistrationController(ILogger<RegistrationController> logger)
		{
			_logger = logger;
		}
		[HttpGet("Employee")]
		public async Task<IActionResult> Index()
		{
			return View();
		}
	}
}
