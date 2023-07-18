using PeopleDataV1.Extras.Entities;
using PeopleDataV1.Extras.Enums;
using System.Xml.Linq;

namespace PeopleDataV1.Entities
{
    public class People : Entity
    {
        public People(Guid id) : base(id)
        {
        }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EGender Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
    }
}
