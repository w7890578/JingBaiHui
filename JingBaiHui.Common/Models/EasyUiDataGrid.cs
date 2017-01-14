using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JingBaiHui.Common.Models
{
    public class EasyUiDataGrid<T>
    {
        [JsonProperty("rows")]
        public IList<T> Rows { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}