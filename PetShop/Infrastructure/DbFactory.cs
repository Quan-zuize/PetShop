using PetShop.Models;

namespace PetShop.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private CodecampN3Context context;
        public CodecampN3Context Init()
        {
            return context ?? (context = new CodecampN3Context());
        }

        protected override void DisposeCore() {
            if(context != null)
            {
                context.Dispose();
            }
        }
    }
}
