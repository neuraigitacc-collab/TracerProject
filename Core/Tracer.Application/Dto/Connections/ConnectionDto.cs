using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Application.Dto.Connections
{
    public class ConnectionDto
    {
        public string Name { get; set; }
        public long Code { get; set; }

        public string type { get; set; }
        public string Icon { get; set; } = null!;

        public string? Description { get; set; }
        public string Color { get; set; }

        public propertiesDto propertice { get; set; }
        public visualDto visual { get; set; }
    }
}
