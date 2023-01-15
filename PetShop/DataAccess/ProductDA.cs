using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public interface IProductCategoryRepository
    {
        IEnumerable<Product> GetByName(string name);
        IEnumerable<Product> GetAllByCategory(int categoryId, int pageIndex, int pageSize, out int totalRow);
    }
    public class ProductDA : RepositoryBase<Product>, IProductCategoryRepository
    {
        public ProductDA(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetAllByCategory(int categoryId, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Products
                        join cp in DbContext.CategoryProducts
                        on p.Id equals cp.ProductId
                        where cp.CategoryId == categoryId
                        select p;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return this.DbContext.Products.Where(p => p.Name == name);
        }

    }
}
