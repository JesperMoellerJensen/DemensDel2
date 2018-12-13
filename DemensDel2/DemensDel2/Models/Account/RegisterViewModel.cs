using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email addresse mangler")]
        [EmailAddress, MaxLength(300)]
        [Display(Name = "Email Addresse")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Kodeord mangler")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords skal stemme overens")]
        [Display(Name = "Bekræft password")]
        public string ConfirmPassword { get; set; }
    }
}
