using PetShop.Infrastructure;
using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class CustomerOrder : BaseEntity
{
    public int? CustomerId { get; set; }

    public int? OrderId { get; set; }
}
