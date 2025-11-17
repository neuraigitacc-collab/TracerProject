using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Application.Dto.Ports;

namespace Tracer.Application.Dto
{
    public record DeviceDto
    {
        public string name { get; set; } = null!;

        public string type { get; set; } = null!;

        //public string Brand { get; set; } = null!;

        //public string Type { get; set; } = null!;
        public string? Description { get; set; }

        public string Icon { get; set; } = null!;

        public string Color { get; set; } = null!;

        public ICollection<LanDto>? Lan { get; set; }
        public ICollection<WanDto>? Wan { get; set; }
        public ICollection<UsbDto>? Usb { get; set; }
        public ICollection<FiberDto>? Fiber { get; set; }
        public ICollection<DslDto>? Dsl { get; set; }
    }
}
