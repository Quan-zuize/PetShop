using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    [Keyless]
    public class CartItem
    {
        public int quantity { set; get; }

        public Product product { set; get; }
    }
}