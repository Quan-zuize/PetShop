using Moq;
using PetShop.Controllers;
using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using PetShop.Service.Products;

namespace TestProject1
{
    public class ProductServiceTest
    {
        private Mock<IProductRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IProductService _productService;
        private List<Product> _listProduct;
        public void Initialize()
        {
            _mockRepository = new Mock<IProductRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _productService = new ProductService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listProduct = new List<Product>() {
                new Product() { Id = 1, Name = "Product1"},
                new Product() { Id = 2, Name = "Product2"},
                new Product() { Id = 3, Name = "Product3"},
            };
        }
        [Fact]
        public void ProductService_GetAll()
        {
            Initialize();
            _mockRepository.Setup(m => m.GetAll()).Returns(_listProduct);
            var result = _productService.GetAll() as List<Product>; 
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }
    }
}