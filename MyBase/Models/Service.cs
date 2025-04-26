using System;
using System.Collections.Generic;

namespace MyBase.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Orderservice> Orderservices { get; set; } = new List<Orderservice>();
}
