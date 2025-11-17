using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracer.Application.Dto.Ports;

namespace Tracer.Application.Dto
{
    public class DeviceListDto
    {
        public string Name { get; set; }

        public int? Code { get; set; }

        public string Icon { get; set; }

       public List<DeviceDto> Devices { get; set; }
    }
}