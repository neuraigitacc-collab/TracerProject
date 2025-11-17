using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class DslforDevice
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int Dslid { get; set; }

    public int Count { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual Dslport Dsl { get; set; } = null!;
}
