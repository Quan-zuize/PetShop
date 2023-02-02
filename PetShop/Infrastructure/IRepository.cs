using System.Linq.Expressions;

namespace PetShop.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> Delete(int id);
        T GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index, int size, string[]includes = null);
    }
}
