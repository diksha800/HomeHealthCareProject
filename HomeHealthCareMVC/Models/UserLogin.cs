using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeHealthCareMVC.Models
{
    public class UserLogin
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //  [Required]
        //  [StringLength(maximumLength: 40, MinimumLength = 5,
        //ErrorMessage = "Username {0} should have {1} maximum characters and {2} minimum characters")]
        //  public string Username { get; set; }
        //  [Required]
        //  [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //  [DataType(DataType.Password)]
        //  [Display(Name = "Password")]
        //  public string Password { get; set; }

        //  [DataType(DataType.Password)]
        //  [Display(Name = "Confirm password")]
        //  [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //  public string ConfirmPassword { get; set; }
        //  public UserType UserType { get; set; }
    }
}
