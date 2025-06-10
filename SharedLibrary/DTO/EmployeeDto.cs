using SharedLibrary.Models.Employee;

namespace SharedLibrary.DTO
{
    public class EmployeeDto
    {
        public required Guid EmployeeId { get; set; }

        public List<WorkSchedule> WorkSchedules { get; set; } = new();

        public required string Name { get; set; }

        public required string Password { get; set; }

        public required string NumberPhone { get; set; }

        public required string Role { get; set; }
    }
}
