using PetShop.Bussiness.Categories;
using PetShop.DataAccess;
using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepos;
        IUnitOfWork _unitOfWork;

        public CategoryService(CategoryDA categoryRepos, IUnitOfWork unitOfWork)
        {
            _categoryRepos = categoryRepos;
            _unitOfWork = unitOfWork;
        }

        public void Add(Category category)
        {
            _categoryRepos.Add(category);
        }

        public void Delete(int id)
        {
            _categoryRepos.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepos.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepos.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Category category)
        {
            _categoryRepos.Update(category);
        }
    }
}
