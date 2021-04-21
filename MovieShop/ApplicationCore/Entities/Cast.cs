using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Cast
    {
        public int Id { get; set; }

#nullable enable
        public string? Name { get; set; }
#nullable enable
        public string? Gender { get; set; }
#nullable enable
        public string? ProfilePath { get; set; }
#nullable enable
        public string?  TmdbUrl { get; set; }

        //creat a foreign key
        public ICollection<MovieCast>? MovieCasts { get; set; }
        
    }
}
