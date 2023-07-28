using CsvHelper.Configuration.Attributes;
using PeopleDataV1.Extras.Enums;
using System.ComponentModel.DataAnnotations;

namespace PeopleDataV1.ViewModels.Persons
{
    public class RegisterPersonCsvViewModel
    {
        [Name("Index")]
        public int Index { get; set; }

        [Name("User Id")]
        public string UserId { get; set; }

        [Name("First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Name("Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Name("Sex")]
        [Required(ErrorMessage = "Gender is required.")]
        public EGender Sex { get; set; }

        [Name("Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;

        [Name("Phone")]
        public string Phone { get; set; } = string.Empty;

        [Name("Date of birth")]
        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Name("Job Title")]
        public string JobTitle { get; set; } = string.Empty;
    }
}