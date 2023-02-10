using PetShop.Models;

namespace PetShop.Service.Products
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetAll();
        //IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Product> GetAllByCategory(int categoryId);
        Product GetById(int id);
        void SaveChanges();
    }
}
