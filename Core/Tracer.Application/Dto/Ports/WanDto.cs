using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracer.Application.Dto.Ports
{
    public class WanDto
    {
        public long Code { get; set; }

        public string Title { get; set; } = null!;

        public string Model { get; set; } = null!;
    }
}