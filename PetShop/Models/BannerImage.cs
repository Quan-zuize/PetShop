using PetShop.Infrastructure;
using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class BannerImage : BaseEntity
{
    public string? Link { get; set; }

    public string? SubTitle { get; set; }

    public string? Image { get; set; }
}
