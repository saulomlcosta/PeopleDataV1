using PeopleDataV1.Extras.Entities;
using PeopleDataV1.Extras.Enums;

namespace PeopleDataV1.Entities
{
    public class User : Entity
    {
        public User(Guid id) : base(id)
        {
            CreateDate = DateTime.Now;
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ERole Role { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
