using SharedLibrary.Models.Cafe;
using SharedLibrary.DataBase_and_more;
using SharedLibrary.Repository.Default;

namespace SharedLibrary.Repository
{
    public class CategoryRepository : Repository<Category, WebDbForCafe>, IDisposable
    {
        private bool disposed = false;

        public CategoryRepository(WebDbForCafe context) : base(context) { }

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
