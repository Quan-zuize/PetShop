using PetShop.Models;

namespace PetShop.Bussiness.Categories
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        IEnumerable<Category> GetAll();
        //IEnumerable<Category> GetAllByParentId(int parentId);
        Category GetById(int id);
        void SaveChanges();
    }
}
