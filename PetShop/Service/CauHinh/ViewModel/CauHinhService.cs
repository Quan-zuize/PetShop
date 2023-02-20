using PetShop.IRepositories;
using PetShop.Models;

namespace PetShop.Service.CauHinhs
{
    public class CauHinhService : ICauHinhService
    {
        ICauHinhRepository _cauhinhRepos;
        public CauHinhService(ICauHinhRepository cauhinhRepos)
        {
            _cauhinhRepos = cauhinhRepos;
        }
        public CauHinh GetCauHinhByTenCauHinh(string name)
        {
            return _cauhinhRepos.GetCauHinhByName(name);
        }
    }
}
