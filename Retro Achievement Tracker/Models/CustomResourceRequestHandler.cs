using CefSharp;
using CefSharp.Handler;
using System.Drawing;
using System.IO;

namespace Retro_Achievement_Tracker.Models
{
    public class CustomResourceRequestHandler : ResourceRequestHandler
    {
        protected override IResourceHandler GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            //Notes:
            // - The 'host' portion is entirely ignored by this scheme handler.
            // - If you register a ISchemeHandlerFactory for http/https schemes you should also specify a domain name
            // - Avoid doing lots of processing in this method as it will affect performance.
            // - Uses the Default ResourceHandler implementation
            switch (request.Url)
            {
                case "disk://default-background": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Properties.Resources.notification_background));
                case "disk://default-rank-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Properties.Resources.rank_image));
                case "disk://default-points-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Properties.Resources.points_image));
                case "disk://default-site-awards-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Properties.Resources.site_awards_image));
                case "disk://default-game-achievements-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Properties.Resources.game_achievements_image));
                case "disk://default-game-points-image": return ResourceHandler.FromByteArray(GetBitmapAsByteArray(Properties.Resources.game_points_image));
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
        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            //Only intercept specific Url's
            if (request.Url.Contains("disk://"))
            {
                return new CustomResourceRequestHandler();
            }

            //Default behaviour, url will be loaded normally.
            return null;
        }
    }
}
