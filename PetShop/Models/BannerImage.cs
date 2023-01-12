using System;
using System.Collections.Generic;

namespace PetShop.Models;

public partial class BannerImage
{
    public int BannerId { get; set; }

    public string? Link { get; set; }

    public string? SubTitle { get; set; }

    public string? Image { get; set; }
}
