using SharedLibrary.Models.Cafe;
using SharedLibrary.Models.Customers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using SharedLibrary.Models.Employee;

namespace SharedLibrary.DataBase_and_more
{
    public class WebDbForEmployee : DbContext
    {

        public WebDbForEmployee(DbContextOptions<WebDbForEmployee> options) : base(options)
        {
            //_ = Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<WorkSchedule> WorkSchedules { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
