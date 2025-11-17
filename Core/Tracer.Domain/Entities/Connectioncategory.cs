using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Connectioncategory
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Icon { get; set; }

    public string? Color { get; set; }

    public virtual ICollection<Cable> Cables { get; set; } = new List<Cable>();
}
