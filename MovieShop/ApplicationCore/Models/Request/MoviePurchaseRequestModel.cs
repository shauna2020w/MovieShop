using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MoviePurchaseRequestModel
    {
        public int MovieId { get; set; }
        public decimal Price { get; set; }
        public decimal AccountBalance { get; set; }

    }
}
