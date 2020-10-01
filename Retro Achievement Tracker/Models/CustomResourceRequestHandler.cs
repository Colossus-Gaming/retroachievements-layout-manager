using CefSharp;
using CefSharp.Handler;
using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.IO;

namespace Retro_Achievement_Tracker.Models
{
    public class CustomResourceRequestHandler : ResourceRequestHandler
    {
        public bool customAchievementEnabled;
        public bool customMasteryEnabled;

        protected override IResourceHandler GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            //Notes:
            // - The 'host' portion is entirely ignored by this scheme handler.
            // - If you register a ISchemeHandlerFactory for http/https schemes you should also specify a domain name
            // - Avoid doing lots of processing in this method as it will affect performance.
            // - Uses the Default ResourceHandler implementation
            switch (request.Url)
            {
                case "disk://background": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Resources.notification_background));
                case "disk://rank-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Resources.rank_image));
                case "disk://points-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Resources.points_image));
                case "disk://site-awards-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Resources.site_awards_image));
                case "disk://game-achievements-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Resources.game_achievements_image));
                case "disk://game-points-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Resources.game_points_image));
            }

            if (request.Url == "disk://achievement-notification")
            {
                if (customAchievementEnabled)
                {
                    return ResourceHandler.FromFilePath(Settings.Default.notification_custom_achievement_file, null, true);
                }
                else
                {
                    return ResourceHandler.FromFilePath("video/achievement-notification.webm", null, true);
                }
            }

            if (request.Url == "disk://mastery-notification")
            {
                if (customMasteryEnabled)
                {
                    return ResourceHandler.FromFilePath(Settings.Default.notification_custom_mastery_file);
                }
                else
                {
                    return ResourceHandler.FromFilePath("video/mastery-notification.webm");
                }
            }

            return ResourceHandler.FromFilePath("" + request.Url.Replace("disk://", ""));
        }

        private byte[] GetBitmapAsByteArray(Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }
    }

    public class CustomRequestHandler : RequestHandler
    {
        public bool customAchievementEnabled;
        public bool customMasteryEnabled;

        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            //Only intercept specific Url's
            if (request.Url.Contains("disk://"))
            {
                return new CustomResourceRequestHandler()
                {
                    customAchievementEnabled = customAchievementEnabled,
                    customMasteryEnabled = customMasteryEnabled
                };
            }

            //Default behaviour, url will be loaded normally.
            return null;
        }
    }
}
