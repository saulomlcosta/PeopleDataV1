using Microsoft.EntityFrameworkCore;
using PeopleDataV1.Data;
using PeopleDataV1.Entities;
using PeopleDataV1.Services.Interfaces;
using System.Xml.Linq;

namespace PeopleDataV1.Services
{
    public class UserService : IBaseService<User>
    {
        private readonly DbContextClass _context;

        public UserService(DbContextClass context)
        {
            _context = context;
        }

        public User Add(User model)
        {
            var result = _context.Users.Add(model);
            _context.SaveChanges();

            return result.Entity;
        }

        public bool Delete(Guid id)
        {
            var filteredData = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            var result = _context.Remove(filteredData);
            _context.SaveChanges();
            return result != null ? true : false;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public User Update(User model)
        {
            var result = _context.Users.Update(model);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
