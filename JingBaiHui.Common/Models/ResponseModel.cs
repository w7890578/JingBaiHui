using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JingBaiHui.Common.Models
{
    public class ResponseModel
    {
        public string Msg { get; set; }
        public bool Status { get; set; }
        public object Value { get; set; }
    }
}