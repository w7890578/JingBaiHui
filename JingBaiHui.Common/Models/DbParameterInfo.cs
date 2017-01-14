using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JingBaiHui.Common.Models
{
    public class DbParameterInfo
    {
        public bool IsEnableOutPut { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}