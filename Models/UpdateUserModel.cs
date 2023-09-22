using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Models
{
    public class UpdateUserModel
    {
        public string UserId { get; set; }

        [EmailAddress]
        [Display(Name = "Username")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// 1 - USER, 2 - ADMIN
        /// </summary>
        public string Role { get; set; }
        public string RoleId { get; set; }

    }
}
