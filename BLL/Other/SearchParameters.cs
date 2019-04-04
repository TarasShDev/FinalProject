using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Other
{
    public class SearchParameters
    {
        public DateTime? dateFrom { get; set; }
        public int? userId { get; set; }
        public int? testId { get; set; }
        public int? scoreMin { get; set; }
        public int? scoreMax { get; set; }
        public TimeSpan? maxPassedTime { get; set; }
    }
}
