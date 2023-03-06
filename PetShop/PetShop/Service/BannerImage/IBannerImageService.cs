using PetShop.Models;

namespace PetShop.Bussiness.BannerImages
{
    public interface IBannerImageService
    {
        IEnumerable<BannerImage> GetAll();
    }
}
