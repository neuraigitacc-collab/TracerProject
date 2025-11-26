using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Application.Dto
{
    public class SavedItemDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public IFormFile SaveData { get; set; }
    }
}
