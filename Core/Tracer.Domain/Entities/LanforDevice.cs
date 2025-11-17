using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class LanforDevice
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int Lanid { get; set; }

    public int Count { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual Lanport Lan { get; set; } = null!;
}
