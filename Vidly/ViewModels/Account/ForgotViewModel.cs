using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels.Account
{


    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}