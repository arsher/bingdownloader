using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSerfozo.BingBackground.Model
{
    internal static class ScreenSizes
    {
        public static readonly ReadOnlyCollection<Size> Sizes = new ReadOnlyCollection<Size>(new List<Size>
        {
            new Size()
            {
                Width = 320,
                Height = 240
            },
            new Size()
            {
                Width = 640,
                Height = 480
            },
            new Size()
            {
                Width = 1024,
                Height = 768
            },
            new Size() 
            {
                Width = 1366,
                Height = 768
            },
            new Size()
            {
                Width = 1920,
                Height = 1080
            },
            new Size()
            {
                Width = 1920,
                Height = 1200
            }
        });

        public static Size ThumbnailSize
        {
            get { return Sizes.First(); }
        }

        public static Size GetClosest(Size size)
        {
            var result = size;
            if (Sizes.All(s => s != size))
            {
                result = Sizes.FirstOrDefault(s => s.Width >= size.Width && s.Height >= size.Height) ?? Sizes.Last();
            }
            return result;
        }
    }
}