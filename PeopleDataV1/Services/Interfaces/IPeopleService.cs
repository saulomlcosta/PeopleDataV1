using PeopleDataV1.ViewModels.Persons;

namespace PeopleDataV1.Services.Interfaces
{
    public interface IPeopleservice
    {
        Task<IEnumerable<PersonViewModel>> GetAllAsync();
        Task<PersonViewModel> GetByIdAsync(Guid id);
        Task<PersonViewModel> AddAsync(RegisterPersonViewModel model);
        Task<PersonViewModel> UpdateAsync(UpdatePersonViewModel model);
        Task<bool> DeleteAsync(Guid id);
        Task<int> ImportPeopleFromCsvAsync(Stream csvStream, Guid userId);
    }
}
