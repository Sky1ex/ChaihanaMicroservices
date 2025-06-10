using ChaihanaForEmplyee.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Repository.Default;

namespace ChaihanaForEmplyee.Controllers
{
	public class RegistrationController : Controller
	{
		private readonly ILogger<RegistrationController> _logger;
		private readonly RegistrationService _registrationService;

		public RegistrationController(ILogger<RegistrationController> logger, RegistrationService registrationService)
		{
			_logger = logger;
			_registrationService = registrationService;
		}

		// ДОДЕЛАТЬ!!!
		[HttpGet("Employee/Authorization")]
		public async Task<IActionResult> Authorization(string login, string password)
		{
			var user = await _registrationService.CheckPassword(login, password);
			return Ok(user);
		}
	}
}
