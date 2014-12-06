using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DSerfozo.BingBackground.Model
{
    public class H
    {
        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("locx")]
        public int Locx { get; set; }

        [JsonProperty("locy")]
        public int Locy { get; set; }
    }
}