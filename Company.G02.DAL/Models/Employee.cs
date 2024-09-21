using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G02.DAL.Models
{
    public class Employee:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public int? Age { get; set; }
   
        public string Address { get; set; }
        [Required]
   
        public decimal Salary { get; set; }
     
        public string  Email { get; set; }
   
        public string  PhoneNumber { get; set; }
        public bool  IsActive { get; set; }
        public bool  IsDeleted { get; set; }
        public DateTime  HiringDate { get; set; }
        public DateTime  DateOfCreation { get; set; } = DateTime.Now;
        [ForeignKey("Department")]
        public int DepartmentId {  get; set; }
        [InverseProperty("Employee")]
        public Department Departments {  get; set; }
    }
}
