using DefaultLibrary.DataBase;
using DefaultLibrary.Repository.Default;
using Microsoft.EntityFrameworkCore;
using DefaultLibrary.DataBase_and_more;
using DefaultLibrary.Models.Customers;

namespace DefaultLibrary.Repository
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
