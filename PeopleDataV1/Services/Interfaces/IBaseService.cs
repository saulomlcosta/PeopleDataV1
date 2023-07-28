using PeopleDataV1.ViewModels.Peoples;

namespace PeopleDataV1.Services.Interfaces
{
    public interface IBaseService<TViewModel, TEntity, TRegisterViewModel, TUpdateViewModel>
        where TViewModel : class
        where TEntity : class
        where TRegisterViewModel : class
        where TUpdateViewModel : class
    {
        Task<IEnumerable<TViewModel>> GetAllAsync();
        Task<TViewModel> GetByIdAsync(Guid id);
        Task<TViewModel> AddAsync(TRegisterViewModel model);
        Task<TViewModel> UpdateAsync(TUpdateViewModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
