using System.Linq.Expressions;
using static Dapper.SqlMapper;

namespace PetShop.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        T GetById(int? id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            string includeProperties);
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index, int size, string[]includes = null);
        Task<IEnumerable<T>> GetMultiPaged(int pageIndex, int pageSize);
    }
}
