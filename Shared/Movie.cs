using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinetown.Shared
{
    public class Movie
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;
        [JsonProperty("director")]
        public string Director { get; set; } = string.Empty;
        [JsonProperty("cast")]
        public string Cast { get; set; } = string.Empty;
        [JsonProperty("genre")]
        public string Genre { get; set; } = string.Empty;
        [JsonProperty("notes")]
        public string Notes { get; set; } = string.Empty;
        [JsonProperty("year")]
        public int? Year { get; set; }
        [JsonProperty("runningTimes"),JsonRequired]
        public RunningTimes? RunningTimes { get; set; }
    }


    public class RunningTimes
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("mon")]
        public List<string>? Mon { get; set; }

        [JsonProperty("tue")]
        public List<string>? Tue { get; set; }

        [JsonProperty("wed")]
        public List<string>? Wed { get; set; }

        [JsonProperty("thu")]
        public List<string>? Thu { get; set; }

        [JsonProperty("fri")]
        public List<string>? Fri { get; set; }

        [JsonProperty("sat")]
        public List<string>? Sat { get; set; }

        [JsonProperty("sun")]
        public List<string>? Sun { get; set; }
    }
}
