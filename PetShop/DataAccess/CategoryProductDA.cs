using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.DataAccess
{
    
    public class CategoryProductDA : RepositoryBase<CategoryProduct>, ICategoryProductRepository
    {
        public CategoryProductDA(CodecampN3Context context) : base(context)
        {
        }
    }
}
