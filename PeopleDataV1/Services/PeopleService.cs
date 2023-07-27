using PeopleDataV1.Data;
using PeopleDataV1.Entities;
using PeopleDataV1.Services.Interfaces;
using PeopleDataV1.ViewModels.Peoples;
using PeopleDataV1.ViewModels.Users;

namespace PeopleDataV1.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly DbContextClass _context;

        public PeopleService(DbContextClass context)
        {
            _context = context;
        }
        public People Add(RegisterPeopleViewModel model)
        {
            var people = new People
            {
                UserId = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Sex = model.Sex,
                Email = model.Email,
                Phone = model.Phone,
                DateOfBirth = model.DateOfBirth,
                JobTitle = model.JobTitle
            };

            var result = _context.Peoples.Add(people);
            _context.SaveChanges();

            return result.Entity;
        }      

        public bool Delete(Guid id)
        {
            var filteredData = _context.Peoples.Where(x => x.Id == id).FirstOrDefault();
            var result = _context.Remove(filteredData);
            _context.SaveChanges();
            return result != null ? true : false;
        }

        public IEnumerable<People> GetAll()
        {
            return _context.Peoples.ToList();
        }

        public People GetById(Guid id)
        {
            return _context.Peoples.Where(x => x.Id == id).FirstOrDefault();
        }

        public People Update(People model)
        {
            var result = _context.Peoples.Update(model);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
