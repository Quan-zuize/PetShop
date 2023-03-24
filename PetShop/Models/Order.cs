using PetShop.Infrastructure;
using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class Order : BaseEntity
{
    public DateTime? OrderDate { get; set; }

    public string? OrderStatus { get; set; }

    public decimal? Total { get; set; }

    public int? Customer_id { get; set; }   
    public string? Fullname { get; set;}
    public string? Address { get; set; }
    public string? Telephone { get; set; }
    public string? Comment { get;set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

}
