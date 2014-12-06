using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DSerfozo.BingBackground.Model;

namespace DSerfozo.BingBackground
{
    public class ImageStore 
    {
        private const string Format = "{0}_{1}x{2}{3}";
        private readonly HttpClient client;

        public ImageStore(HttpClient client)
        {
            this.client = client;
        }

        public async Task<byte[]> GetThumbnail(BingImage image)
        {
            var response = await GetImageAtResolution(image, ScreenSizes.ThumbnailSize);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            throw new BingImageNotAvailableException();
        }

        public async Task<byte[]> GetImage(BingImage image, Size size)
        {
            var closestValidSize = ScreenSizes.GetClosest(size);
            var response = await GetImageAtResolution(image, closestValidSize);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            throw new BingImageNotAvailableException();
        }

        private Task<HttpResponseMessage> GetImageAtResolution(BingImage image, Size resolution)
        {
            var extension = Path.GetExtension(image.Url);
            var imgUrl = string.Format(Format, image.Urlbase, resolution.Width, resolution.Height, extension);
            return client.GetAsync(imgUrl);
        }
    }
}