using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Application.Dto.Connections
{
    public class visualDto
    {
        public string Strokewidth { get; set; } 

        public string? Strokedasharray { get; set; }

        public bool Showarrow { get; set; }

        public string Linestyle { get; set; }
    }
}
