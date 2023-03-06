using PetShop.Models;

namespace PetShop.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        CodecampN3Context Init();

    }
}
