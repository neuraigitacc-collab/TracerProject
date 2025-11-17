using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Devicestype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Code { get; set; }

    public string Icon { get; set; } = null!;

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
