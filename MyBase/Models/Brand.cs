using System;
using System.Collections.Generic;

namespace MyBase.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
