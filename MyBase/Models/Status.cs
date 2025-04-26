using System;
using System.Collections.Generic;

namespace MyBase.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Repairorder> Repairorders { get; set; } = new List<Repairorder>();
}
