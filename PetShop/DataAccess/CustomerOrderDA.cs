using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public interface ICustomerOrderRepository : IRepository<CustomerOrder>
    {

    }
    public class CustomerOrderDA : RepositoryBase<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderDA(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
