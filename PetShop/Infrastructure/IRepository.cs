using System.Linq.Expressions;

namespace PetShop.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index, int size, string[]includes = null);
    }
}
