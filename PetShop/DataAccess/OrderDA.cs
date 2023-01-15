using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public interface IOrderRepository : IRepository<Order>
    {

    }
    public class OrderDA : RepositoryBase<Order>, IOrderRepository
    {
        public OrderDA(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
