using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PeopleDataV1.Services.Interfaces;

namespace PeopleDataV1.Services;

public class BaseService<TViewModel, TEntity, TRegisterViewModel, TUpdateViewModel> : IBaseService<TViewModel, TEntity, TRegisterViewModel, TUpdateViewModel>
    where TViewModel : class
    where TEntity : class
    where TRegisterViewModel : class
    where TUpdateViewModel : class
{
    private readonly DbContext _context;
    private readonly IMapper _mapper;

    public BaseService(DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TViewModel>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        return _mapper.Map<IEnumerable<TViewModel>>(entities);
    }

    public async Task<TViewModel> GetByIdAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        return _mapper.Map<TViewModel>(entity);
    }

    public async Task<TViewModel> AddAsync(TRegisterViewModel model)
    {
        var entity = _mapper.Map<TEntity>(model);
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<TViewModel>(entity);
    }

    public async Task<TViewModel> UpdateAsync(TUpdateViewModel model)
    {
        var idProperty = typeof(TEntity).GetProperty("Id");
        var entityId = idProperty.GetValue(model);
        var entity = await _context.Set<TEntity>().FindAsync(entityId);

        if (entity == null)
        {
            throw new ArgumentException("Entity not found.");
        }

        _mapper.Map(model, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TViewModel>(entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);

        if (entity == null)
        {
            return false;
        }

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }
}
