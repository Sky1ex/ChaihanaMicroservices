using SharedLibrary.Models.Customers;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.DataBase_and_more;
using SharedLibrary.Repository.Default;

namespace SharedLibrary.Repository
{
    public class CartRepository : Repository<Cart, WebDbForCustomers>, IDisposable
    {
        private bool disposed = false;

        public CartRepository(WebDbForCustomers context) : base(context) { }

        public async Task<Cart?> GetByUserId(Guid userId)
        {
            return await _context.Carts
                .FirstOrDefaultAsync(x => x.User.UserId == userId);
        }

        public async Task<Cart?> GetByUserIdWithCartElements(Guid userId)
        {
            return await _context.Carts
                .Include(x => x.CartElement)
                .FirstOrDefaultAsync(x => x.User.UserId == userId);
        }

        public async Task<Cart?> GetByUserIdFull(Guid userId)
        {
            return await _context.Carts
                .Include(x => x.CartElement)
                .FirstOrDefaultAsync(x => x.User.UserId == userId);
        }

        public async Task<Cart?> GetByUserIdFullWithoutTracking(Guid userId)
        {
            return await _context.Carts
                .AsNoTracking()
                .Include(x => x.CartElement)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.User.UserId == userId);
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
