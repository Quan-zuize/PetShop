using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public class CustomerDA : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerDA(CodecampN3Context context) : base(context)
        {
        }
    }
}
