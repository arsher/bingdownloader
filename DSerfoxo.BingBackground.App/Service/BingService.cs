using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Size = DSerfozo.BingBackground.Model.Size;

namespace DSerfozo.BingBackground.App.Service
{
    public class BingService
    {
        private readonly Size screenSize;
        private readonly StorageService storageService;
        private readonly Dispatcher dispatcher;
        private readonly HttpClient httpClient;
        private readonly MetadataStore metadataStore;
        private readonly ImageStore imageStore;
        private readonly Timer timer;

        public event EventHandler<ImageAvailableEventArgs> NewImageAvailable;

        public BingService(Uri bingUri, StorageService storageService, Dispatcher dispatcher)
        {
            this.storageService = storageService;
            this.dispatcher = dispatcher;
            httpClient = new HttpClient
            {
                BaseAddress = bingUri
            };
            metadataStore = new MetadataStore(httpClient);
            imageStore = new ImageStore(httpClient);
            timer = new Timer(CheckBing, null, TimeSpan.FromMilliseconds(-1), TimeSpan.FromHours(3));
            screenSize = new Size((int) SystemParameters.PrimaryScreenWidth, (int) SystemParameters.PrimaryScreenHeight);
        }

        public void Start()
        {
            timer.Change(TimeSpan.Zero, TimeSpan.FromHours(3));
        }

        public Task Refresh()
        {
            return CheckBingInternal();
        }

        private void CheckBing(object state)
        {
            CheckBingInternal();
        }

        private async Task CheckBingInternal()
        {
            var today = await metadataStore.DownloadTodayAsync();
            if (!storageService.BackgroundExists(today))
            {
                var thumbnailArray = await imageStore.GetThumbnail(today);
                var imageArray = await imageStore.GetImage(today, screenSize);
                storageService.StoreImage(today, imageArray, thumbnailArray);

                Wallpaper.Set(storageService.CurrentImagePath, Wallpaper.Style.Centered);
                RaiseNewImageAvailableOnUi(storageService.CurrentImagePath, storageService.CurrentThumbnailPath);
            }
        }

        private void RaiseNewImageAvailableOnUi(string path, string thumbnailPath)
        {
            if (!dispatcher.CheckAccess())
            {
                dispatcher.Invoke(new Action(() => RaiseNewImageAvailableOnUi(path, thumbnailPath)));
            }
            else
            {
                RaiseNewImageAvailable(path, thumbnailPath);
            }
        }

        private void RaiseNewImageAvailable(string path, string thumbnailPath)
        {
            var handler = NewImageAvailable;
            if (handler != null)
            {
                handler(this, new ImageAvailableEventArgs(path, thumbnailPath));
            }
        }
    }
}