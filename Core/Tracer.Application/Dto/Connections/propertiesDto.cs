using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Application.Dto.Connections
{
    public class propertiesDto
    {
        public double Bandwidth { get; set; }

        public double Latency { get; set; }

        public int Maxdistance { get; set; }
        
        public string Duplex { get; set; }
    }
}
