using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Property
{
    public int Id { get; set; }

    public int Cableid { get; set; }

    public double Bandwidth { get; set; }

    public double Latency { get; set; }

    public int Maxdistance { get; set; }

    public string Duplex { get; set; } = null!;

    public virtual Cable Cable { get; set; } = null!;
}
