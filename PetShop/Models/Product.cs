using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ProductType { get; set; }

    public string? Image { get; set; }

    public string? Price { get; set; }

    public string? OriginalPrice { get; set; }

    public string? Description { get; set; }

    public string? Specification { get; set; }
}
