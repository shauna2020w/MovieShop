using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }
#nullable enable
        public string? ReviewText { get; set; }

        //fk
#nullable disable
        public User User { get; set; }
#nullable disable
        public Movie Movie { get; set; }
    }
}
