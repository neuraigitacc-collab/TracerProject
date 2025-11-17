using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class UsbforDevice
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int Usbid { get; set; }

    public int Count { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual Usbport Usb { get; set; } = null!;
}
