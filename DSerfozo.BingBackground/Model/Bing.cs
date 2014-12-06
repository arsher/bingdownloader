using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DSerfozo.BingBackground.Model
{
    public class Bing
    {
        [JsonProperty("images")]
        public IList<BingImage> Images { get; set; }

        [JsonProperty("tooltips")]
        public Tooltips Tooltips { get; set; }
    }
}