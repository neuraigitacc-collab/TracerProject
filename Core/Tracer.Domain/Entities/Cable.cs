using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Cable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public long Code { get; set; }

    public string Model { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Icon { get; set; } = null!;

    public string? Description { get; set; }

    public string Color { get; set; } = null!;

    public virtual Connectioncategory Category { get; set; } = null!;

    public virtual Code CodeNavigation { get; set; } = null!;

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();

    public virtual ICollection<Visual> Visuals { get; set; } = new List<Visual>();
}
