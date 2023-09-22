using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Models
{
	public class LoginModel
	{
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Username")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
