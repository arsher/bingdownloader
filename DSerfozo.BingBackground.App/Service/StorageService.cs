using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DSerfozo.BingBackground.Model;

namespace DSerfozo.BingBackground.App.Service
{
    public class StorageService
    {
        private const string ThumbnailSuffix = "_thumbnail";
        private const string ThumbnailFormat = "{0}" + ThumbnailSuffix + "{1}";

        private readonly string storageDir =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Assembly.GetExecutingAssembly().GetName().Name);

        private readonly DirectoryInfo directoryInfo;
        private string currentImageName;

        public string CurrentImagePath
        {
            get { return Path.Combine(storageDir, currentImageName); }
        }

        public string CurrentThumbnailPath
        {
            get
            {
                return Path.Combine(storageDir,
                    string.Format(ThumbnailFormat, Path.GetFileNameWithoutExtension(currentImageName),
                        Path.GetExtension(currentImageName)));
            }
        }

        public StorageService()
        {
            directoryInfo = new DirectoryInfo(storageDir);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            else
            {
                ClearData();
            }
        }

        public bool BackgroundExists(BingImage image)
        {
            return File.Exists(Path.Combine(storageDir, image.Urlbase + image.FileExtension));
        }

        public void StoreImage(BingImage image, byte[] imageArray, byte[] thumbnailArray)
        {
            ClearData();
            var fileName = image.Urlbase.Split('/').Last();
            currentImageName = fileName + image.FileExtension;
            using (var imageStream = File.OpenWrite(CurrentImagePath))
            using (var thumbnailStream = File.OpenWrite(CurrentThumbnailPath))
            {
                imageStream.Write(imageArray, 0, imageArray.Length);
                thumbnailStream.Write(thumbnailArray, 0, thumbnailArray.Length);
            }
        }

        private void ClearData()
        {
            directoryInfo.EnumerateFiles()
                .ToList()
                .ForEach(f => f.Delete());

            currentImageName = string.Empty;
        }
    }
}