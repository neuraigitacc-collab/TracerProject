using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Application.Dto.Connections;

namespace Tracer.Application.Dto
{
    public class CableListDto
    {
        public string Name { get; set; } 

        public string Icon { get; set; }

        public ICollection<ConnectionDto> connections { get; set; }

    }
}