using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.DomainModels
{
    public class UserModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "First name required")]
        [DisplayName("first name")]
        public string FirstName { get; set; }
        [DisplayName("last name")]
        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address")]
        [DisplayName("email")]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(28, MinimumLength = 4, ErrorMessage = "you must specify password between 4 and 8 characters")]

        public string password { get; set; }
        public string token { get; set; }

    }
}
