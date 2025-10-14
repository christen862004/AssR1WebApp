using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace AssR1WebApp.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURl { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

    }
}
