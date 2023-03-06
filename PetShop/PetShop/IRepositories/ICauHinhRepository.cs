using PetShop.Infrastructure;
using PetShop.Models;

namespace PetShop.IRepositories
{
    public interface ICauHinhRepository:IRepository<CauHinh>
    {
        CauHinh GetCauHinhByName(string name);
    }
}
