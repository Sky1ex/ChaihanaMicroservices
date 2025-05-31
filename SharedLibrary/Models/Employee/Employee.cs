using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Employee
{
	public class Employee
	{
		public required Guid EmployeeId { get; set; }

		public List<WorkSchedule> WorkSchedules { get; set; } = new();

		public required string Name { get; set; }

		public required string Password { get; set; }

		public required string NumberPhone { get; set; }

		public required string Role {  get; set; }
	}
}
