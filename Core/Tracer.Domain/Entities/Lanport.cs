using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Lanport
{
    public int Id { get; set; }

    public long Code { get; set; }

    public string Title { get; set; } = null!;

    public string Model { get; set; } = null!;

    public DateTime Createtime { get; set; }

    public DateTime? Updatetime { get; set; }

    public bool Isdelete { get; set; }

    public virtual Code CodeNavigation { get; set; } = null!;

    public virtual ICollection<LanforDevice> LanforDevices { get; set; } = new List<LanforDevice>();
}
