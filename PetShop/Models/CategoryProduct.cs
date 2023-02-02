using PetShop.Infrastructure;
using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class CategoryProduct : BaseEntity
{
    public int? ProductId { get; set; }

    public int? CategoryId { get; set; }
}
