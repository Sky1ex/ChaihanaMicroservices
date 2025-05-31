using SharedLibrary.Models.Cafe;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.DataBase_and_more;
using SharedLibrary.Repository.Default;

namespace SharedLibrary.Repository
{
    public class ProductRepository : Repository<Product, WebDbForCafe>, IDisposable
    {
        private bool disposed = false;

        public ProductRepository(WebDbForCafe context) : base(context) { }


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

        public List<Product> GetProducts(List<Guid> guids)
        {
			return _context.Products.Where(x => guids.Contains(x.ProductId)).ToList();
		}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
