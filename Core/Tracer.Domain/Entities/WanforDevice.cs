using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class WanforDevice
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int Wanid { get; set; }

    public int Count { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual Wanport Wan { get; set; } = null!;
}
