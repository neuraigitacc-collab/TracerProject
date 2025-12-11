using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Connectiondatum
{
    public int Id { get; set; }

    public string Savedata { get; set; } = null!;
    public string Title { get; set; } = null!;

    public bool Isdelete { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime? Updatetime { get; set; }
}
