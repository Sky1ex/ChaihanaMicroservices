using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.Employee
{
	public class WorkSchedule
	{
		public Guid WorkScheduleId { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public string status { get; set; }

		public Employee Employee { get; set; }
	}
}
