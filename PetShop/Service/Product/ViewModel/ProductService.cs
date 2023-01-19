using PetShop.DataAccess;
using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.Service.Products
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepos;
        IUnitOfWork _unitOfWork;
        public ProductService(ProductDA productRepos, IUnitOfWork unitOfWork)
        {
            this._productRepos = productRepos;
            this._unitOfWork = unitOfWork; 
        }
        public void Add(Product product)
        {
            _productRepos.Add(product);
        }

        public void Delete(int id)
        {
            _productRepos.Delete(id);
        }
        public void Update(Product product)
        {
            _productRepos.Update(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepos.GetAll();
        }

        public IEnumerable<Product> GetAllPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            return _productRepos.GetMultiPaging(x => x.Id == categoryId , out totalRow, page, pageSize, new string[] {"CategoryProduct"});
        }

        public Product GetById(int id)
        {
            return _productRepos.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

    }
}
