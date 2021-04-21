using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Response
{
    public class MovieDetailResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
#nullable enable
        public int? Runtime { get; set; }
#nullable enable
        public DateTime? CreatedDate { get; set; }
#nullable enable
        public ICollection<Genre>? Genres { get; set; }
#nullable enable
        public string? Overview { get; set; }
#nullable enable
        public DateTime? ReleaseDate { get; set; }
#nullable enable
        public decimal? BoxOffice { get; set; }
#nullable enable
        public decimal? Budget { get; set; }
#nullable enable
        public string? PosterUrl { get; set; }
#nullable enable
        public string? Rating { get; set; }
#nullable enable
        public List<CastModel>? CastCollection { get; set; }
    }
}
