using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace DSerfozo.BingBackground.App.Service
{
    public class ImageAvailableEventArgs : EventArgs
    {
        public string Path { get; set; }

        public string ThumbnailPath { get; set; }

        public ImageAvailableEventArgs(string path, string thumbnailPath)
        {
            Path = path;
            ThumbnailPath = thumbnailPath;
        }
    }
}