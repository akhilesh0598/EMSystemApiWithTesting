using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Models.Requets
{
    public class EmployeeRequest
    {
        [EmailAddress(ErrorMessage ="emial Id shuold be example@mail.com type")]
        [Required]
        public string EmailId { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        
    }
}
