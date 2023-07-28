using PeopleDataV1.Entities;
using PeopleDataV1.ViewModels.Users;

namespace PeopleDataV1.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(Guid id);
        Task<UserViewModel> AddAsync(RegisterUserViewModel model);
        Task<UserViewModel> UpdateAsync(UpdateUserViewModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
