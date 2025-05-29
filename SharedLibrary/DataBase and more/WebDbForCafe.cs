using DefaultLibrary.Models.Cafe;
using DefaultLibrary.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace DefaultLibrary.DataBase_and_more
{
    public class WebDbForCafe : DbContext
	{

		public WebDbForCafe(DbContextOptions<WebDbForCafe> options) : base(options)
		{
			//_ = Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}

		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }
	}
}
