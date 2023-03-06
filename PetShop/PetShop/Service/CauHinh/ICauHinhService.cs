using PetShop.Models;

namespace PetShop.Service.CauHinhs
{
    public interface ICauHinhService
    {
        CauHinh GetCauHinhByTenCauHinh(string name);
    }
}
