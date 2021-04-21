using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Response
{
    public class MovieReviewResponseModel
    {
        public int UserId { get; set; }     
        public string ReviewContent { get; set; }
        public decimal? Rating { get; set; }

    }
}
