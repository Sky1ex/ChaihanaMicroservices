using WebApplication1.DataBase;
using WebApplication1.Repository.Default;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DataBase_and_more;
using AspireForChaihana.ServiceDefaults.Models.Customers;

namespace WebApplication1.Repository
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
