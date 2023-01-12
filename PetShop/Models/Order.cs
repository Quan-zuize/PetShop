using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public decimal? Total { get; set; }

    public DateTime? DateAdded { get; set; }
}
