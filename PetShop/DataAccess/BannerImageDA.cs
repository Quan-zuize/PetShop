using PetShop.Infrastructure;
using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.DataAccess
{
    public class BannerImageDA : RepositoryBase<BannerImage>, IBannerImageRepository
    {
        public BannerImageDA(CodecampN3Context context) : base(context)
        {
        }
    }
}
