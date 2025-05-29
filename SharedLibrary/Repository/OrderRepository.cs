using DefaultLibrary.Models.Customers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using DefaultLibrary.DataBase;
using DefaultLibrary.DataBase_and_more;
using DefaultLibrary.Repository.Default;

namespace DefaultLibrary.Repository
{
    public class OrderRepository : Repository<Order, WebDbForCustomers>, IDisposable
    {
        private bool disposed = false;

        public OrderRepository(WebDbForCustomers context) : base(context) { }

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
