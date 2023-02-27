using Dapper;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;

using System.Linq.Expressions;
using static Dapper.SqlMapper;

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
                return context ??= new DbFactory().Init();
            }
        }

        public RepositoryBase(CodecampN3Context context)
        {
            this.context = context;
            dbSet = DbContext.Set<T>();
        }

        #region Implemetation
        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"No {nameof(T)}  Entity was provided for Insert");
            }
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //T entityToUpdate = dbSet.AsNoTracking().SingleOrDefault(e => e.Id == entity.Id);
            //if (entityToUpdate == null)
            //{
            //    throw new ArgumentNullException($"No {nameof(T)}  Entity was provided for Update");
            //}
            //dbSet.Update(entity);
        }
        public virtual void Delete(T entity)
        {
            try
            {
                if(context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual void Delete(int id)
        {
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    dbSet.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual T GetById(int? id)
        {
            try
            {
                //return dbSet.SingleOrDefault(s => s.Id == id);
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return dbSet.AsEnumerable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        {
            IQueryable<T> query = dbSet;
            if(expression != null)
            {
                query = query.Where(expression);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            if (includes != null && includes.Length > 0)
            {
                var query = context.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
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

        public async Task<IEnumerable<T>> GetMultiPaged(int pageIndex, int pageSize)
        {
            return await dbSet.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        #endregion
    }
}
