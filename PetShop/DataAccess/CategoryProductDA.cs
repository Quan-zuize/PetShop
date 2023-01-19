using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public interface ICategoryProductRepository : IRepository<CategoryProduct>
    {

    }
    public class CategoryProductDA : RepositoryBase<CategoryProduct>, ICategoryProductRepository
    {
        public CategoryProductDA(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
