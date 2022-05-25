using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Models.DB
{
    public class EmployeeDTO
    {
        [Key]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; } 
        [MaxLength(50)]
        public string Qualification { get; set; }
        [Required]
        [Phone]
        [MaxLength(100)]
        public string ContactNumber { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }

    }
}
