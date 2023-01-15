using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public interface ICategoryRepository : IRepository<Category>
    {

    }
    public class CategoryDA : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryDA(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
