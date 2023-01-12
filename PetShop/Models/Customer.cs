using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Avatar { get; set; }

    public string? Adress { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? Status { get; set; }

    public string? Password { get; set; }

    public DateTime? DateAdded { get; set; }
}
