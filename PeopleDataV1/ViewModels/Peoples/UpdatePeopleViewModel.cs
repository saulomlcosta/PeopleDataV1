using PeopleDataV1.Extras.Enums;
using System.ComponentModel.DataAnnotations;

namespace PeopleDataV1.ViewModels.Peoples
{
    public class UpdatePeopleViewModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User id is required.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required.")]
        public EGender Sex { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        public string JobTitle { get; set; } = string.Empty;
    }
}