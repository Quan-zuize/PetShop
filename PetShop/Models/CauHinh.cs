using PetShop.Infrastructure;

namespace PetShop.Models
{
    public partial class CauHinh : BaseEntity
    {
        public string? TenCauHinh { get; set; }
        public string? GiaTriCauHinh { get; set; }
    }
}
