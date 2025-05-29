using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repository.Default
{
	public interface IUnitOfWorkCustomers
	{
		CartRepository Carts { get; }
		AddressRepository Addresses { get; }
		OrderRepository Orders { get; }
		CartElementRepository CartElements { get; }
		UserRepository Users { get; }
		BookingRepository Bookings { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
