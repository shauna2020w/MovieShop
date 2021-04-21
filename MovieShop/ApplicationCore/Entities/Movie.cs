using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        public decimal? Revenue { get; set; }
        public decimal? Budget { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
#nullable enable
        public string? Overview { get; set; }
#nullable enable
        public string? Tagline { get; set; }
#nullable enable
        public string? ImdbUrl { get; set; }
#nullable enable
        public string? TmdbUrl { get; set; }
#nullable enable
        public string? PosterUrl { get; set; }
#nullable enable
        public string? BackdropUrl { get; set; }
#nullable enable
        public string? OriginalLanguage { get; set; }
#nullable enable
        public DateTime? ReleaseDate { get; set; }
#nullable enable
        public int? RunTime { get; set; }
#nullable enable
        public decimal? Price { get; set; }
#nullable enable
        public DateTime? CreatedDate { get; set; }
#nullable enable
        public DateTime? UpdatedTime { get; set; }
#nullable enable
        public string? CreatedBy { get; set; }
#nullable enable
        public string? UpdatedBy { get; set; }
#nullable enable
        public string? Rating { get; set; }

        //Navigation Property
#nullable enable
        public ICollection<Trailer>? Trailers { get; set; }
#nullable enable
        public ICollection<Genre>? Genres { get; set; }
#nullable enable
        public ICollection<MovieCast>? MovieCasts { get; set; }
#nullable enable
        public Purchase? Purchase { get; set; } //one purchase per movie
#nullable enable
        public ICollection<Review>? Reviews { get; set; } //one review per movie



    }
}
