using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02.DAL.MODELS
{
    public class TableInfo
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }
        public string Default { get; set; }
    }
}
