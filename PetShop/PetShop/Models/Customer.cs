using PetShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Models;

public partial class Customer : BaseEntity
{
    public string? Name { get; set; }

    public string? Avatar { get; set; }

    public string? Adress { get; set; }
    [DataType(DataType.PhoneNumber)]

    public string? ContactNumber { get; set; }
    [DataType(DataType.EmailAddress)]

    public string? Email { get; set; }

    public string? Status { get; set; }
    [DataType(DataType.Password)]

    public string? Password { get; set; }

    public DateTime? DateAdded { get; set; }
}
