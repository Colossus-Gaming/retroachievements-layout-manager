using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace Retro_Achievement_Tracker.Models
{
    class MediaHelper
    {
        internal static string HexConverter(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        internal static decimal GetVideoWidth(string input)
        {
            if (File.Exists(input))
            {
                var inputFile = new MediaFile { Filename = input };
                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);
                }
                var frameSize = inputFile.Metadata.VideoData.FrameSize;

                return Convert.ToInt32(frameSize.Substring(0, frameSize.IndexOf("x")));
            }
            return 0;
        }

        internal static int GetVideoDuration(string input)
        {
            if (File.Exists(input))
            {
                var inputFile = new MediaFile { Filename = input };

                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);
                }
                return Convert.ToInt32(inputFile.Metadata.Duration.TotalMilliseconds, CultureInfo.CurrentCulture);
            }
            return 0;
        }
    }
}
