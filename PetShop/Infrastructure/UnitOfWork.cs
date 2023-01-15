using PetShop.Models;

namespace PetShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private CodecampN3Context context;
        public CodecampN3Context Context()
        {
            return context ?? (context = new CodecampN3Context());
        }
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
