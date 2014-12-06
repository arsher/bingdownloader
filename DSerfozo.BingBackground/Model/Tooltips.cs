using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DSerfozo.BingBackground.Model
{
    public class Tooltips 
    {
        [JsonProperty("loading")]
        public string Loading { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("walle")]
        public string Walle { get; set; }

        [JsonProperty("walls")]
        public string Walls { get; set; }
    }
}