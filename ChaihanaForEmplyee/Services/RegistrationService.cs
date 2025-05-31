using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Repository.Default;

namespace ChaihanaForEmplyee.Services
{
	public class RegistrationService
	{
		private IUnitOfWorkEmployee _unitOfWorkEmployee;

		public RegistrationService(IUnitOfWorkEmployee unitOfWorkEmployee)
		{
			_unitOfWorkEmployee = unitOfWorkEmployee;
		}

		/*async Task<IActionResult> CheckPassword(string password)
		{

		}*/
	}
}
