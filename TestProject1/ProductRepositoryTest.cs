using Moq;
using PetShop.DataAccess;
using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;
using PetShop.Service.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace TestProject1
{
    
    public class ProductRepositoryTest
    {
        CodecampN3Context context = new CodecampN3Context();
        IDbFactory dbFactory = new CodecampN3Context();
        IProductRepository productRepository;
        IUnitOfWork unitOfWork;
        public void Initialize()
        {
            dbFactory = new DbFactory();
            productRepository = new ProductDA(context);
            unitOfWork = new UnitOfWork(context);
        }

        [Fact]
        public void GetProduct_ReturnAll()
        {
            Initialize();
            var productList = productRepository.GetAll().ToList();
            Assert.Equal(10, productList.Count);
        }
        [Fact]
        public void GetService_ReturnAll()
        {
            Initialize();
            var serviceList = productRepository.GetAllServices().ToList();
            Assert.Equal(10, serviceList.Count);
        }
    }
}
