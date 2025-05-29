using AspireForChaihana.ServiceDefaults.Models.Cafe;
using AspireForChaihana.ServiceDefaults.Models.Customers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace WebApplication1.DataBase
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
