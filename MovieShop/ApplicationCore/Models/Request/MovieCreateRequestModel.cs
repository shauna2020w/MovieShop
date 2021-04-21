using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MovieCreateRequestModel
    {
        public string Title { get; set; }
#nullable enable
        public string? Overview { get; set; } //reference type
#nullable enable
        public string? Tagline { get; set; }
#nullable enable
        public DateTime? CreatedTime { get; set; }
#nullable enable
        public string? CreatedBy { get; set; }
        public decimal? Budget { get; set; } // value type,leave it tbd
        public decimal? Revenue { get; set; }
    }
}
