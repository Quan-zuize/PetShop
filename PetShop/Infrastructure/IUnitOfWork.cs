using PetShop.IRepositories;

namespace PetShop.Infrastructure
{
    public interface IUnitOfWork
    {
        ICategoryProductRepository CategoryProducts { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        Task CompleteAsync();
        void Commit();
    }
}
