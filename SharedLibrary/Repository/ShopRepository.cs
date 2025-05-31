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
	public class ShopRepository : Repository<Shop, WebDbForEmployee>, IDisposable
	{
		private bool disposed = false;

		public ShopRepository(WebDbForEmployee context) : base(context) { }

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
