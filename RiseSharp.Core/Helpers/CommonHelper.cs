using System;

namespace RiseSharp.Core.Helpers
{
    public static class CommonHelper
    {
        public static int GetEpochTime()
        {
            var dt = new DateTime(2016, 4, 24, 17, 0, 0).ToUniversalTime();
            var time = new DateTime().ToUniversalTime();
            var utcTime = dt.ToUniversalTime();

            return (int) Math.Floor((utcTime - time).TotalSeconds/1000);
        }
    }
}
