namespace Accountant.Data
{
    public interface IEntityProvider<T> where T : class
    {
        Task<T> SaveAsync(T entity);
    }
}