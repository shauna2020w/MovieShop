using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
#nullable enable
        public string? TrailerUrl { get; set; }
#nullable enable
        public string? Name { get; set; }

        //creat a foreign key
        public int MovieId { get; set; }
#nullable disable
        public Movie Movie { get; set; }
    }
}
