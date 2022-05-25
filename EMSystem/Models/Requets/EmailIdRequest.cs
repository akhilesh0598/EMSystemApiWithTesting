using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Models.Requets
{
    public class EmailIdRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "emial Id shuold be example@mail.com type")]
        public string EmailId { get; set; }
    }
}
