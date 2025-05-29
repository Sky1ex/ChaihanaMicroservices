using System.Data.Entity;
using WebApplication1.DataBase;
using WebApplication1.DataBase_and_more;

namespace WebApplication1.Repository.Default
{
	public class UnitOfWorkCustomers : IUnitOfWorkCustomers
	{
		protected readonly WebDbForCustomers _context;

		public UnitOfWorkCustomers(WebDbForCustomers context)
		{
			_context = context;
			Carts = new CartRepository(_context);
			Addresses = new AddressRepository(_context);
			Orders = new OrderRepository(_context);
			CartElements = new CartElementRepository(_context);
			Users = new UserRepository(_context);
			Bookings = new BookingRepository(_context);
		}

		public CartRepository Carts { get; }
		public AddressRepository Addresses { get; }
		public OrderRepository Orders { get; }
		public CartElementRepository CartElements { get; }
		public UserRepository Users { get; }
		public BookingRepository Bookings { get; }

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
