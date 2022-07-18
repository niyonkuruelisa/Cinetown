using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinetown.Shared
{
    public class Seat
    {
        public string id { get; set; }
        public int row { get; set; }
        public int column { get; set; }

        public string state { get; set; } = "n/a";

    }
}
