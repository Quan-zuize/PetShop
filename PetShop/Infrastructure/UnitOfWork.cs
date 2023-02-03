using PetShop.DataAccess;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private CodecampN3Context context;
        private RepositoryBase<Product> productRepository;
        private RepositoryBase<Category> categoryRepository;

        public RepositoryBase<Category> Categories { get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryDA(context);
                }
                return categoryRepository;
            } 
        }
        public RepositoryBase<Product> Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductDA(context);
                }
                return productRepository;
            }

        }

        //public UnitOfWork(CodecampN3Context context)
        //{
        //    this.context = context;

        //    Categories = new CategoryDA(context);
        //    CategoryProducts = new CategoryProductDA(context);
        //    Products = new ProductDA(context);
        //}

        public void Commit()
        {
            context.SaveChanges();
        }

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
