using PetShop.IRepositories;

namespace PetShop.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        //ICategoryProductRepository CategoryProducts { get; }
        //ICategoryRepository Categories { get; }
        //IProductRepository Products { get; }
        void Commit();
    }
}
