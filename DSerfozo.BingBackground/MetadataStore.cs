using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DSerfozo.BingBackground.Model;
using Newtonsoft.Json;

namespace DSerfozo.BingBackground
{
    public class MetadataStore
    {
        private const string DefaultMarket = "en-US";
        private const string Format = "HPImageArchive.aspx?format=js&idx=0&n=1&mkt={0}";
        private readonly HttpClient client;

        public string Market { get; set; }

        public MetadataStore(HttpClient client)
        {
            this.client = client;

            Market = DefaultMarket;
        }

        public async Task<BingImage> DownloadTodayAsync()
        {
            try
            {
                var stringResult = await client.GetStringAsync(string.Format(Format, Market));
                var images = JsonConvert.DeserializeObject<Bing>(stringResult);
                return images.Images.First();
            }
            catch (Exception e)
            {
                throw new BingImageNotAvailableException(e);
            }
        }
    }
}