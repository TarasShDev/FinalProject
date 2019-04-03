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
        int? userId { get; set; }
        int? testId { get; set; }
        int? scoreMin { get; set; }
        int? scoreMax { get; set; }
        TimeSpan? passedTime { get; set; }
    }
}
