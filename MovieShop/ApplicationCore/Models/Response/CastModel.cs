using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Response
{
    public class CastModel
    {
        public string ProfilePath { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        //public List<Movie> Movies { get; set; }
        public string Movies { get; set; }
    }
}
