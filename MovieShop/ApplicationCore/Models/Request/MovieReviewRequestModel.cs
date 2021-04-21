using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MovieReviewRequestModel
    {
        public int MovieId { get; set; }
        public bool? Favorite { get; set; }

        public decimal? Rating { get; set; }
        public string ReviewContent { get; set; }
    }
}
