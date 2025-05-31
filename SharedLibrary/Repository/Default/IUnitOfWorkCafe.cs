using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Repository;

namespace SharedLibrary.Repository.Default
{
	public interface IUnitOfWorkCafe
	{
		ProductRepository Products { get; }
		CategoryRepository Categories { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
