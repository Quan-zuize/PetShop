using PetShop.Bussiness.BannerImages;
using PetShop.IRepositories;

namespace PetShop.Service.BannerImage.ViewModel
{
    public class BannerImageService : IBannerImageService
    {
        IBannerImageRepository _bannerRepos;
        public BannerImageService(IBannerImageRepository bannerRepos)
        {
            _bannerRepos = bannerRepos;
        }
        public IEnumerable<Models.BannerImage> GetAll()
        {
            return _bannerRepos.GetAll();
        }
    }
}
