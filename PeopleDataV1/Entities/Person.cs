using PeopleDataV1.Extras.Entities;
using PeopleDataV1.Extras.Enums;
using System.Text.Json.Serialization;

namespace PeopleDataV1.Entities
{
    public class Person : Entity
    {
        public Person() : base(Guid.NewGuid())
        {
        }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; } = null!;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public EGender Sex { get; set; } 
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } 
        public string JobTitle { get; set; } = string.Empty;
    }
}
