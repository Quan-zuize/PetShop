using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.DataAccess
{
    
    public class OrderDetailDA : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailDA(CodecampN3Context context) : base(context)
        {
        }
    }
}
