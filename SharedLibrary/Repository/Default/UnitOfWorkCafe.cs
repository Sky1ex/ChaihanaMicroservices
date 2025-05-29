using DefaultLibrary.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultLibrary.DataBase_and_more;
using DefaultLibrary.Repository;

namespace DefaultLibrary.Repository.Default
{
	public class UnitOfWorkCafe : IUnitOfWorkCafe
	{

		protected readonly WebDbForCafe _context;

		public UnitOfWorkCafe(WebDbForCafe context)
		{
			_context = context;
			Products = new ProductRepository(_context);
			Categories = new CategoryRepository(_context);
		}

		public ProductRepository Products { get; }
		public CategoryRepository Categories { get; }

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
