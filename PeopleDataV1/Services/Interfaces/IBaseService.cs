namespace PeopleDataV1.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(Guid id);
        public T Add(T model);
        public T Update(T model);
        public bool Delete(Guid id);
    }
}
