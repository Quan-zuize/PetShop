using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {

    }
    public class OrderDetailDA : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailDA(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
