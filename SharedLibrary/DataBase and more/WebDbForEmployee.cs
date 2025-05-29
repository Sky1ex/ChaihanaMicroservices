using DefaultLibrary.Models.Cafe;
using DefaultLibrary.Models.Customers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DefaultLibrary.DataBase
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
    }
}
