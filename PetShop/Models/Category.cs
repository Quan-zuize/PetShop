using PetShop.Infrastructure;
using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class Category : BaseEntity
{
    public string? Name { get; set; }

    public int? ParentId { get; set; }
}
