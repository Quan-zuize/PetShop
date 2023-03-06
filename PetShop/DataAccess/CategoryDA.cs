using Dapper;
using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PetShop.DataAccess
{
    public class CategoryDA:RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryDA(CodecampN3Context context) : base(context)
        {
        }
        string conn = new ConnectToDB().ConnectionString;
        public IEnumerable<Category> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(conn))
            {
                var sql = "usp_WEB_GetCategory";
                connection.Open();
                var result = connection.Query<Category>(sql, commandType: System.Data.CommandType.StoredProcedure).ToList();
                connection.Close();
                return result;
            }
        }
        public Category GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(conn))
            {
                var sql = "usp_WEB_Get";
                DynamicParameters dp = new DynamicParameters();
                dp.Add("id", id);
                connection.Open();
                var result = connection.Query<Category>(sql, dp, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                connection.Close();
                return result;
            }
        }
    }
}
