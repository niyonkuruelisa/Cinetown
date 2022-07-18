using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinetown.Shared
{
    public class Ticket
    {
        
        public string Id { get; set; } = String.Empty;
        public string _ticketName { get; set; } = String.Empty;
        public double _price { get; set; } = 0;
        [NotMapped]
        public int _people { get; set; } = 0;
    }
}
