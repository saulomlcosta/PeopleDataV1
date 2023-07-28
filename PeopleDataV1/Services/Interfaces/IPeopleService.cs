using PeopleDataV1.ViewModels;
using PeopleDataV1.ViewModels.Persons;

namespace PeopleDataV1.Services.Interfaces
{
    public interface IPeopleservice
    {
        Task<PagedResult<PersonViewModel>> GetAllAsync(int page, int pageSize);
        Task<PersonViewModel> GetByIdAsync(Guid id);
        Task<PersonViewModel> AddAsync(RegisterPersonViewModel model);
        Task<PersonViewModel> UpdateAsync(UpdatePersonViewModel model);
        Task<bool> DeleteAsync(Guid id);
        Task<int> ImportPeopleFromCsvAsync(Stream csvStream, Guid userId);
    }
}
