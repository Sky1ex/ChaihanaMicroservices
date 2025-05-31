using SharedLibrary.Repository.Default;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.DataBase_and_more;
using SharedLibrary.Models.Customers;

namespace SharedLibrary.Repository
{
    public class AddressRepository : Repository<Adress, WebDbForCustomers>, IDisposable
    {
        private bool disposed = false;

        public AddressRepository(WebDbForCustomers context) : base(context) { }

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
