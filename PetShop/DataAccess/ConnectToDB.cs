namespace PetShop.DataAccess
{
    public class ConnectToDB
    {
        public string connectionString = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build().GetConnectionString("DefaultConnection").ToString();
    }
}
