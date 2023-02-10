using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace PetShop.DataAccess
{
    public class ProductDA : RepositoryBase<Product>, IProductRepository
    {
        public ProductDA(CodecampN3Context context) : base(context)
        {
        }
        public IEnumerable<Product> GetAllByCategory(int categoryId/*, int pageIndex, int pageSize, out int totalRow*/)
        {
            var sql = "usp_WEB_GetProductByCategoryId";
            using (var connection = new SqlConnection("DefaultConnection"))
            {
                connection.Open();
                //Add param
                DynamicParameters dp = new DynamicParameters();
                dp.Add("CategoryId", categoryId);
                var result = connection.QueryFirst<Product>;
            }
            var query = from p in DbContext.Products
                        join cp in DbContext.CategoryProducts
                        on p.Id equals cp.ProductId
                        where cp.CategoryId == categoryId
                        select p;
            //totalRow = query.Count();
            //query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}
