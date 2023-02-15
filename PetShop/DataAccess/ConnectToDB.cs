using Microsoft.Data.SqlClient;

namespace PetShop.DataAccess
{
    public class ConnectToDB
    {
        private readonly static IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        public SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}
