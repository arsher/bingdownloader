using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DSerfozo.BingBackground.Model
{
    public class BingImage
    {
        [JsonProperty("startdate")]
        public string Startdate { get; set; }

        [JsonProperty("fullstartdate")]
        public string Fullstartdate { get; set; }

        [JsonProperty("enddate")]
        public string Enddate { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlbase")]
        public string Urlbase { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("copyrightlink")]
        public string Copyrightlink { get; set; }

        [JsonProperty("wp")]
        public bool Wp { get; set; }

        [JsonProperty("hsh")]
        public string Hsh { get; set; }

        [JsonProperty("drk")]
        public int Drk { get; set; }

        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("bot")]
        public int Bot { get; set; }

        [JsonProperty("hs")]
        public IList<H> Hs { get; set; }

        [JsonProperty("msg")]
        public IList<object> Msg { get; set; }

        [JsonIgnore]
        public string FileExtension
        {
            get { return Path.GetExtension(Url); }
        }
    }
}