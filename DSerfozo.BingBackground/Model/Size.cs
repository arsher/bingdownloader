using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSerfozo.BingBackground.Model
{
    public class Size
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Size()
        {
        }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public static bool operator ==(Size size1, Size size2)
        {
            return size1.Width == size2.Width && size1.Height == size2.Height;
        }

        public static bool operator !=(Size size1, Size size2)
        {
            return !(size1 == size2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var s = (Size) obj;
            return s == this;
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash*23 + Width.GetHashCode();
            hash = hash*23 + Height.GetHashCode();
            return hash;
        }
    }
}