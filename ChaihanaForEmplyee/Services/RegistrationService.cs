using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using SharedLibrary.DataBase_and_more;
using SharedLibrary.DTO;
using SharedLibrary.Models.Employee;
using SharedLibrary.Repository.Default;

namespace ChaihanaForEmplyee.Services
{
	public class RegistrationService
	{
		private IUnitOfWorkEmployee _unitOfWorkEmployee;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;

		public RegistrationService(IUnitOfWorkEmployee unitOfWorkEmployee, IHttpContextAccessor httpContextAccessor, IMapper mapper)
		{
			_unitOfWorkEmployee = unitOfWorkEmployee;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<EmployeeDto> CheckPassword(string login, string password)
		{
			var user = await _unitOfWorkEmployee.Employee.GetUserByNameAndPassword(login, password);
            var httpContext = _httpContextAccessor.HttpContext;


			if (user == null) return null;

            AuthOptions.SetJwtCookie(httpContext, user.EmployeeId, user.Role);

			return _mapper.Map<EmployeeDto>(user);
        }
	}
}
