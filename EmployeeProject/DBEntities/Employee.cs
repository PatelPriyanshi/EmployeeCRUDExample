using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.DBEntities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string EmployeeTagNumber { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public int? Age { get; set; }
        public string? Designation {  get; set; }

    }
}
