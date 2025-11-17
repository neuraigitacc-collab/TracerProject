using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Code
{
    public int Id { get; set; }

    public long Code1 { get; set; }

    public bool Used { get; set; }

    public virtual ICollection<Cable> Cables { get; set; } = new List<Cable>();

    public virtual Dslport? Dslport { get; set; }

    public virtual Fiberport? Fiberport { get; set; }

    public virtual Lanport? Lanport { get; set; }

    public virtual Usbport? Usbport { get; set; }

    public virtual Wanport? Wanport { get; set; }
}
