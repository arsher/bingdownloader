using System;

namespace DSerfozo.BingBackground
{
    public class BingImageNotAvailableException : Exception
    {
        public BingImageNotAvailableException()
        {
        }

        public BingImageNotAvailableException(Exception e)
            : base("", e)
        {
        }
    }
}