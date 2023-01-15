using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public interface ICustomerRepository : IRepository<Customer> { }
    public class CustomerDA : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerDA(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
