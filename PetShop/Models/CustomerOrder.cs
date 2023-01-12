using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class CustomerOrder
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? OrderId { get; set; }
}
