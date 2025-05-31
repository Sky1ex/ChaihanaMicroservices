using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Employee
{
	public class Shop
	{
		public Guid ShopId { get; set; }

		public required string Name { get; set; }

		public required string City { get; set; }

		public required string Street { get; set; }

		public required string House { get; set; }
	}
}
