using PeopleDataV1.Extras.Enums;

namespace PeopleDataV1.ViewModels.Persons
{
    public class PersonViewModel
    {       
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public EGender Sex { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string JobTitle { get; set; } = string.Empty;
    }
}