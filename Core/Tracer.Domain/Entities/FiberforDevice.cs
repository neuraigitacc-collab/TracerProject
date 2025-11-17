using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class FiberforDevice
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int Sfid { get; set; }

    public int Count { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual Fiberport Sf { get; set; } = null!;
}
