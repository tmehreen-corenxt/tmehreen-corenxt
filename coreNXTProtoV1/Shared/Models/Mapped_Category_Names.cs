using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreNXTProtoV1.Models
{
    public class Mapped_Category_Names
    {
        public int CategoryId { get; set; }
        public int LocaleId { get; set; }

        public string? Name { get; set; }
    }
}
