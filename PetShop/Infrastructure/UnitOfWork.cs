using PetShop.DataAccess;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private CodecampN3Context context;

        public ICategoryProductRepository CategoryProducts { get; set; }

        public ICategoryRepository Categories { get; set; }
        public IProductRepository Products { get; set; }

        public UnitOfWork(CodecampN3Context context)
        {
            this.context = context;
            
            Categories = new CategoryDA(context);
            CategoryProducts = new CategoryProductDA(context);
            Products = new ProductDA(context);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
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
