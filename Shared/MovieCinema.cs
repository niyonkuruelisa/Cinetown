using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinetown.Shared
{
    public class MovieCinema
    {
        public int id { get; set; }
        public Movie Movie { get; set; }
        public Cinema Cinema { get; set; }
    }
}
