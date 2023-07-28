using PeopleDataV1.ViewModels.Peoples;

namespace PeopleDataV1.Services.Interfaces
{
    public interface IPeopleservice
    {
        Task<IEnumerable<PeopleViewModel>> GetAllAsync();
        Task<PeopleViewModel> GetByIdAsync(Guid id);
        Task<PeopleViewModel> AddAsync(RegisterPeopleViewModel model);
        Task<PeopleViewModel> UpdateAsync(UpdatePeopleViewModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
