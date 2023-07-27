namespace PeopleDataV1.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
         IEnumerable<T> GetAll();
         T GetById(Guid id);
         T Add(T model);
         T Update(T model);
         bool Delete(Guid id);
    }
}
