using System;
using System.Collections.Generic;

namespace MyBase.Models;

public partial class Device
{
    public int DeviceId { get; set; }

    public int? CustomerId { get; set; }

    public int? DeviceType { get; set; }

    public int? BrandId { get; set; }

    public string Model { get; set; } = null!;

    public virtual Brand? Brand { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual DevicesType? DeviceTypeNavigation { get; set; }

    public virtual ICollection<Repairorder> Repairorders { get; set; } = new List<Repairorder>();
}
