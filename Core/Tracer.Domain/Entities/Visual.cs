using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Visual
{
    public int Id { get; set; }

    public int Cableid { get; set; }

    public string Strokewidth { get; set; } = null!;

    public string? Strokedasharray { get; set; }

    public bool Showarrow { get; set; }

    public string Linestyle { get; set; } = null!;

    public virtual Cable Cable { get; set; } = null!;
}
