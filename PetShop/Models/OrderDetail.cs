﻿using PetShop.Infrastructure;
using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class OrderDetail : BaseEntity
{
    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public string? Total { get; set; }

    public int? Quantity { get; set; }
}
