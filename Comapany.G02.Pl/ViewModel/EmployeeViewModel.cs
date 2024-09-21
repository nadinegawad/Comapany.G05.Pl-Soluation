using Company.G02.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Comapany.G02.Pl.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required !!")]
        public string Name { get; set; }
        [Range(25, 60, ErrorMessage = "Age must between 25 and 60")]
        public int? Age { get; set; }
        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$", ErrorMessage = "Addrees must be like 123-street-city-country")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Salary Is Required !!")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
    
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [InverseProperty("Employee")]
        public Department Departments { get; set; }
    }
}
