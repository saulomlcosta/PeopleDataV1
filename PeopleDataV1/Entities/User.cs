using PeopleDataV1.Extras.Entities;
using PeopleDataV1.Extras.Enums;

namespace PeopleDataV1.Entities
{
    public class User : Entity
    {
        public User() : base(Guid.NewGuid())
        {
            
            CreateDate = DateTime.Now;
        }

        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
