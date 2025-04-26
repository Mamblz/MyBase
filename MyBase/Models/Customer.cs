using System;
using System.Collections.Generic;

namespace MyBase.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
