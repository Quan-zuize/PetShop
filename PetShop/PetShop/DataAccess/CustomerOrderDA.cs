using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.DataAccess
{
    
    public class CustomerOrderDA : RepositoryBase<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderDA(CodecampN3Context context) : base(context)
        {
        }
    }
}
