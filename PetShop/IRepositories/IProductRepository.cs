using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        //IEnumerable<Product> GetByName(string name);
        IEnumerable<Product> GetAllByCategory(int categoryId, int pageIndex, int pageSize, out int totalRow);
    }
}
