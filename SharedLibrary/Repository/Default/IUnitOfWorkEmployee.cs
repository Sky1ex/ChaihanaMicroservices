using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repository.Default
{
	public interface IUnitOfWorkEmployee
	{
		EmployeeRepository Employee { get; }
		ShopRepository Shop { get; }
		IngredientRepository Ingredient { get; }
		WorkScheduleRepository WorkSchedule { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
