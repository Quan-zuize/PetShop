using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PetShop.DataAccess
{
    public class ProductDA : RepositoryBase<Product>, IProductRepository
    {
        public ProductDA(CodecampN3Context context) : base(context)
        {
        }
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        public IEnumerable<Product> GetAllByCategory(int categoryId/*, int pageIndex, int pageSize, out int totalRow*/)
        {

            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = "usp_WEB_GetProductByCategoryId";
                DynamicParameters dp = new DynamicParameters();
                dp.Add("CategoryId", categoryId);
                connection.Open();
                var result = connection.Query<Product>(sql, dp, commandType: System.Data.CommandType.StoredProcedure).ToList();
                connection.Close();
                return result;
            }
        }
        public Product GetById(int? id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = "usp_WEB_GetProductDetail";
                DynamicParameters dp = new DynamicParameters();
                dp.Add("id", id);
                connection.Open();
                var result = connection.Query<Product>(sql, dp, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                connection.Close();
                return result;
            }
        }
        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = "usp_WEB_GetAllProduct";
                connection.Open();
                var result = connection.Query<Product>(sql, commandType: System.Data.CommandType.StoredProcedure).ToList();
                connection.Close();
                return result;
            }
            //var query = from p in DbContext.Products
            //            join cp in DbContext.CategoryProducts
            //            on p.Id equals cp.ProductId
            //            where cp.CategoryId == categoryId
            //            select p;
            //totalRow = query.Count();
            //query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //return query;
        }

        public IEnumerable<Product> GetAllServices()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var sql = "usp_WEB_GetService";
                connection.Open();
                var result = connection.Query<Product>(sql, commandType: System.Data.CommandType.StoredProcedure).ToList();
                connection.Close();
                return result;
            }
        }
    }
}
