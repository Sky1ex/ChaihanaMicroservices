using Microsoft.EntityFrameworkCore;
using SharedLibrary.DataBase_and_more;
using SharedLibrary.Models.Employee;
using SharedLibrary.Repository.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repository
{
	public class EmployeeRepository : Repository<Employee, WebDbForEmployee>, IDisposable
	{
		private bool disposed = false;

		public EmployeeRepository(WebDbForEmployee context) : base(context) { }

		public async Task<Employee?> GetUserByNameAndPassword(string name, string password)
		{
			return await _context.Employees.FirstOrDefaultAsync(x => x.Name == name && x.Password == password);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
