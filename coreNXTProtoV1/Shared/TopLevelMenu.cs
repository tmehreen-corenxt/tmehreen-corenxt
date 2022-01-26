using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreNXTProtoV1.Shared
{
    public class TopLevelMenu
    {

        public string? ItemName { get; set; } 
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public int LocaleId { get; set; }

    }
}
