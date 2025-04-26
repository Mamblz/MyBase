using System;
using System.Collections.Generic;

namespace MyBase.Models;

public partial class Orderservice
{
    public int OrderServiceId { get; set; }

    public int? OrderId { get; set; }

    public int? ServiceId { get; set; }

    public virtual Service? Service { get; set; }
}
