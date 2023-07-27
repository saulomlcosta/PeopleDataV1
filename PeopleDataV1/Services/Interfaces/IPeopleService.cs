using PeopleDataV1.Entities;
using PeopleDataV1.ViewModels.Peoples;
using PeopleDataV1.ViewModels.Users;

namespace PeopleDataV1.Services.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<People> GetAll();
        People GetById(Guid id);
        People Add(RegisterPeopleViewModel model);
        People Update(People model);
        bool Delete(Guid id);
    }
}
