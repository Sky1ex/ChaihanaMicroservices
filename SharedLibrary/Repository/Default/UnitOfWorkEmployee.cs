using SharedLibrary.DataBase_and_more;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repository.Default
{
	public class UnitOfWorkEmployee : IUnitOfWorkEmployee
	{

		protected readonly WebDbForEmployee _context;

		public UnitOfWorkEmployee(WebDbForEmployee context)
		{
			_context = context;
			Employee = new EmployeeRepository(_context);
			Shop = new ShopRepository(_context);
			WorkSchedule = new WorkScheduleRepository(_context);
			Ingredient = new IngredientRepository(_context);
		}

		public EmployeeRepository Employee { get; }
		public ShopRepository Shop { get; }
		public WorkScheduleRepository WorkSchedule { get; }
		public IngredientRepository Ingredient { get; }

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
