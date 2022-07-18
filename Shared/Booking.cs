using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinetown.Shared
{
    public class Booking
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z]*$", ErrorMessage ="Accepted Only Alphabet characters.")]
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
        [JsonProperty("day")]
        public string Day { get; set; } = string.Empty;
        [JsonProperty("time")]
        public string Time { get; set; } = string.Empty;
        [JsonProperty("movieId")]
        public int? MovieId { get; set; }
        [JsonProperty("cinemaId")]
        public int? CinemaId { get; set; }
        [JsonProperty("seats")]
        public List<Seat>? seats { get; set; }
    }
}
