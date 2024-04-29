using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Employee TagNumber")]
        public string EmployeeTagNumber { get; set; }

        [Required(ErrorMessage ="Please Enter First Name")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public int? Age { get; set; }
        public string? Designation { get; set; }
    }   
}
