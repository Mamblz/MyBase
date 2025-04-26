using System;
using System.Collections.Generic;

namespace MyBase.Models;

public partial class Repairorder
{
    public int OrderId { get; set; }

    public int? DeviceId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int? StatusId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Device? Device { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Status? Status { get; set; }
}
