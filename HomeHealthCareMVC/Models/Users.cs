//using System;
//using System.ComponentModel.DataAnnotations;

//namespace HomeHealthCareMVC.Models
//{
//    public class Users
//    {
     

//        public int ID { get; set; }
     
//        [StringLength(maximumLength: 40, MinimumLength = -1,
//         ErrorMessage = "Username {0} should have {1} maximum characters and {2} minimum characters")]
//        [Required(
//            ErrorMessage = "Username Required")]
//        public string Username { get; set; }
//        [Required (
//             ErrorMessage = "Password Required")]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }
//        [Required]
//        public string FirstName { get; set; }
//        [Required]
//        public string LastName { get; set; }
//        [Required]
//        public UserType UserType { get; set; }
//        public DateTime? CreatedDateTime { get; set; }
//    }
//}