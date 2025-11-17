using System;
using System.Collections.Generic;

namespace Tracer.Domain.Entities;

public partial class Connectionport
{
    public int Id { get; set; }

    public int Firstport { get; set; }

    public int Conectedport { get; set; }

    public int Cable { get; set; }
}
