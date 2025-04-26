using System;
using System.Collections.Generic;

namespace MyBase.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Repairorder> Repairorders { get; set; } = new List<Repairorder>();
}
