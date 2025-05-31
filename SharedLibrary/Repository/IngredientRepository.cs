using SharedLibrary.DataBase_and_more;
using SharedLibrary.Models.Employee;
using SharedLibrary.Repository.Default;

namespace SharedLibrary.Repository
{
	public class IngredientRepository : Repository<Ingredient, WebDbForEmployee>, IDisposable
	{
		private bool disposed = false;

		public IngredientRepository(WebDbForEmployee context) : base(context) { }

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
