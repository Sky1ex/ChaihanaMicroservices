using AspireForChaihana.ServiceDefaults.Models.Cafe;
using AspireForChaihana.ServiceDefaults.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WebApplication1.DataBase_and_more
{
    public class WebDbForCustomers : DbContext
	{

		public WebDbForCustomers(DbContextOptions<WebDbForCustomers> options) : base(options)
		{
			//_ = Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}

		public DbSet<User> Users { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<Booking> Bookings { get; set; }

		public DbSet<CartElement> CartElements { get; set; }

		public DbSet<Cart> Carts { get; set; }

		public DbSet<OrderElement> OrderElements { get; set; }

		public DbSet<Adress> Adresses { get; set; }

		public DbSet<AddressElement> AddressElements { get; set; }
	}
}
