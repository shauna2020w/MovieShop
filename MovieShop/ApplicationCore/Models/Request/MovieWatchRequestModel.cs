using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MovieWatchRequestModel
    {
        public int MovieId { get; set; }
        public bool Watched { get; set; }
        public DateTime WatchTime { get; set; }
    }
}
