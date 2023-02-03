using PetShop.Infrastructure;
using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class Admin : BaseEntity
{
    public string? Name { get; set; }

    public string? Password { get; set; }
}
