using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PeopleDataV1.Data;
using PeopleDataV1.Entities;
using PeopleDataV1.Services.Interfaces;
using PeopleDataV1.ViewModels.Users;

namespace PeopleDataV1.Services
{
    public class UserService : IUserService
    {
        private readonly DbContextClass _context;
        private readonly IMapper _mapper;

        public UserService(DbContextClass context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();           
            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public async Task<UserViewModel> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> AddAsync(RegisterUserViewModel model)
        {
            var user = _mapper.Map<User>(model);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> UpdateAsync(UpdateUserViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

            _mapper.Map(model, user);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
