using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.DataAccess
{
    
    public class OrderDA : RepositoryBase<Order>, IOrderRepository
    {
        public OrderDA(CodecampN3Context context) : base(context)
        {
        }
    }
}
