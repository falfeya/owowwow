namespace CRM.DAL
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<T> Get(int id);
        Task<T> GetByName(string name);

        IQueryable<T> GetAll();

        Task<bool> Delete(T entity);

        Task<T> Update(T entity);
    }
}