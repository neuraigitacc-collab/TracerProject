using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Application.Dto
{
    public class GetSavedDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SavedData { get; set; }
    }
}
