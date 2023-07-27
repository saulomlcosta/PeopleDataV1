using System.ComponentModel.DataAnnotations;

namespace PeopleDataV1.ViewModels.Users
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format for email.")]
        public string Email { get; set; } = string.Empty;
    }
}
