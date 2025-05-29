using DefaultLibrary.Models.Customers;
using DefaultLibrary.DataBase;
using DefaultLibrary.DataBase_and_more;
using DefaultLibrary.Repository.Default;

namespace DefaultLibrary.Repository
{
    public class CartElementRepository : Repository<CartElement, WebDbForCustomers>, IDisposable
    {
        private bool disposed = false;

        public CartElementRepository(WebDbForCustomers context) : base(context) { }

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
