using AspireForChaihana.ServiceDefaults.Models.Customers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataBase;
using WebApplication1.DataBase_and_more;
using WebApplication1.Repository.Default;

namespace WebApplication1.Repository
{
    public class BookingRepository : Repository<Booking, WebDbForCustomers>, IDisposable
	{
        private bool disposed = false;

        public BookingRepository(WebDbForCustomers context) : base(context) { }

        public async Task<List<Booking>> GetBookingsByTableId(int tableId)
        {
            return await _context.Bookings
                .Where(x => x.Table == tableId)
                .ToListAsync();
        }

		public async Task<List<Booking>> GetBookingsByUserId(Guid userId)
		{
			return await _context.Bookings
				.Where(x => x.User.UserId == userId)
				.ToListAsync();
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
