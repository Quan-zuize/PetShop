﻿using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class CategoryProduct
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? CategoryId { get; set; }
}
