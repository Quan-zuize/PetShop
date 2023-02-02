using Dapper;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;

using System.Linq.Expressions;
namespace PetShop.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        protected CodecampN3Context context;
        protected Microsoft.EntityFrameworkCore.DbSet<T> dbSet;

        protected CodecampN3Context DbContext
        {
            get
            {
                return context ??= new CodecampN3Context();
            }    
        }

        public RepositoryBase(CodecampN3Context context)
        {
            this.context = context;
            dbSet = DbContext.Set<T>();
        }

        #region Implemetation
        public virtual async Task<T> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"No {nameof(T)}  Entity was provided for Insert");
            }
            await dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            T entityToUpdate = await dbSet.AsNoTracking().SingleOrDefaultAsync(e => e.Id == entity.Id);
            if (entityToUpdate == null)
            {
                //return null;
                throw new ArgumentNullException($"No {nameof(T)}  Entity was provided for Update");
            }
            dbSet.Update(entity);
            return entity;
        }
        public virtual async Task<T> Delete(T entity)
        {
            try
            {
                dbSet.Remove(entity);
                return await Task.FromResult(entity);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<T> Delete(int id)
        {
            try
            {
                var entity = GetById(id);

                if (entity != null)
                {
                    dbSet.Remove(entity);
                }
                return await Task.FromResult(entity);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public virtual T GetById(int id)
        {
            try
            {
                return dbSet.Find(id);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
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
                _resetSet = expression != null ? dbSet.Where(expression).AsQueryable() : dbSet.AsQueryable();
            }
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }
        #endregion
    }
}
