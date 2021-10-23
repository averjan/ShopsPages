namespace ShopsPages.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int? id);
        bool Add(T entity);
        bool Delete(int? id);
        bool Update(T entity);
    }
}
