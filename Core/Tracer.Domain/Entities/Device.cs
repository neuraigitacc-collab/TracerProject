using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Device
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public DateTime Createtime { get; set; }

    public DateTime? Updatetime { get; set; }

    public bool Isdelete { get; set; }

    public int DeviceType { get; set; }

    public string? Description { get; set; }

    public string Icon { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual Devicestype DeviceTypeNavigation { get; set; } = null!;

    public virtual ICollection<DslforDevice> DslforDevices { get; set; } = new List<DslforDevice>();

    public virtual ICollection<FiberforDevice> FiberforDevices { get; set; } = new List<FiberforDevice>();

    public virtual ICollection<LanforDevice> LanforDevices { get; set; } = new List<LanforDevice>();

    public virtual ICollection<UsbforDevice> UsbforDevices { get; set; } = new List<UsbforDevice>();

    public virtual ICollection<WanforDevice> WanforDevices { get; set; } = new List<WanforDevice>();
}
