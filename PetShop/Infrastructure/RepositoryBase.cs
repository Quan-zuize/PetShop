using PetShop.Models;
using System.Data.Entity;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PetShop.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private CodecampN3Context context;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get; set;
        }
        protected CodecampN3Context DbContext
        {
            get
            {
                return context ?? (context = DbFactory.Init());
            }    
        }
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = (IDbSet<T>?)DbContext.Set<T>();
        }

        #region Implemetation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;
            
            if(includes != null && includes.Length > 0)
            {
                var query = context.Set<T>().Include(includes.First());
                foreach(var include in includes.Skip(1)) {
                    query = query.Include(include);
                }
                _resetSet = expression != null ? query.Where(expression).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = expression != null ? context.Set<T>().Where(expression).AsQueryable() : context.Set<T>().AsQueryable();
            }
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }
        #endregion
    }
}
