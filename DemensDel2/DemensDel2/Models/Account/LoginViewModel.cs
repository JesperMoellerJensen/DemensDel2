using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress, MaxLength(300)]
        [Display(Name = "Email Addresse")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
