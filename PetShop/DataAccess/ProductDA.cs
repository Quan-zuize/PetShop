using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PetShop.DataAccess
{
    public class ProductDA : RepositoryBase<Product>, IProductRepository
    {
        public ProductDA(CodecampN3Context context) : base(context)
        {
        }
        SqlConnection sqlConnection = new ConnectToDB().sqlConnection;
        public IEnumerable<Product> GetAllByCategory(int categoryId/*, int pageIndex, int pageSize, out int totalRow*/)
        {
            using (IDbConnection connection = sqlConnection)
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
        //public Product GetById(int? id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        var sql = "usp_WEB_GetProductDetail";
        //        DynamicParameters dp = new DynamicParameters();
        //        dp.Add("id", id);
        //        connection.Open();
        //        var result = connection.Query<Product>(sql, dp, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
        //        connection.Close();
        //        return result;
        //    }
        //}
        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection connection = sqlConnection)
            {
                var sql = "usp_WEB_GetAllProduct";
                connection.Open();
                var result = connection.Query<Product>(sql, commandType: System.Data.CommandType.StoredProcedure).ToList();
                connection.Close();
                return result;
            }
        }

        public IEnumerable<Product> GetAllServices()
        {
            using (IDbConnection connection = sqlConnection)
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
