using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public class CategoryDA : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryDA(CodecampN3Context context) : base(context)
        {      
        }


    }
}
