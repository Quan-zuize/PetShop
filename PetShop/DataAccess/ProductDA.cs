using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using Dapper;

namespace PetShop.DataAccess
{
    public class ProductDA : RepositoryBase<Product>, IProductRepository
    {
        public ProductDA(CodecampN3Context context) : base(context)
        {
        }

        //public Task<IEnumerable<Product>> GetAllProductsAsync(int pageIndex, int pageSize)
        //{
        //    using (var connection = )
        //}

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

        //public IEnumerable<Product> GetByName(string name)
        //{
        //    return this.DbContext.Products.Where(p => p.Name == name);
        //}

    }
}
