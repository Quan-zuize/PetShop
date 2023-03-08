using Dapper;
using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using System.Data;
using System.Data.SqlClient;

namespace PetShop.DataAccess
{
    public class CauHinhDA : RepositoryBase<CauHinh>, ICauHinhRepository
    {
        public CauHinhDA(CodecampN3Context context) : base(context)
        {
        }
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        public CauHinh GetCauHinhByName(string name)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var sql = "usp_WEB_GetCauHinhByTenCauHinh";
                    //Add param
                    DynamicParameters dp = new DynamicParameters();
                    dp.Add("name", name);
                    connection.Open();
                    var result = connection.QueryFirst<CauHinh>(sql, dp, commandType: System.Data.CommandType.StoredProcedure);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception : "+ e);
            }
        }
    }
}
