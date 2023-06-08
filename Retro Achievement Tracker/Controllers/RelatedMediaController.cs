using Retro_Achievement_Tracker.Forms;
using Retro_Achievement_Tracker.Properties;
using System.Threading.Tasks;

namespace Retro_Achievement_Tracker.Controllers
{
    public sealed class RelatedMediaController
    {
        private static readonly RelatedMediaController instance = new RelatedMediaController();
        private static RelatedMediaWindow RelatedMediaWindow;
        private static string CurrentImageURI;

        public bool IsOpen;

        private RelatedMediaController()
        {

        }
        public static RelatedMediaController Instance
        {
            get
            {
                return instance;
            }
        }
        public void Close()
        {
            if (IsOpen)
            {
                RelatedMediaWindow.Close();
                IsOpen = false;
            }
        }
        public void Show()
        {
            if (!IsOpen)
            {
                if (RelatedMediaWindow == null || RelatedMediaWindow.IsDisposed)
                {
                    RelatedMediaWindow = new RelatedMediaWindow();
                }
                RelatedMediaWindow.Show();
            }
        }
        public void SetAllSettings()
        {
            if (IsOpen)
            {
                RelatedMediaWindow.AssignJavaScriptVariables();
                RelatedMediaWindow.SetWindowBackgroundColor(WindowBackgroundColor);

                UpdateImage();

                RelatedMediaWindow.SetClientSize();
            }
        }
        public async void UpdateImage()
        {
            string imageUri = "";

            switch (RelatedMediaSelection)
            {
                case RelatedMediaSelection.RABadgeIcon:
                    imageUri = RABadgeIconURI;
                    break;
                case RelatedMediaSelection.RATitleScreen:
                    imageUri = RATitleScreenURI;
                    break;
                case RelatedMediaSelection.RAIngameScreen:
                    imageUri = RAScreenshotURI;
                    break;
                case RelatedMediaSelection.RABoxArt:
                    imageUri = RABoxArtURI;
                    break;
                case RelatedMediaSelection.LBBoxArtFront:
                    imageUri = "http://appassets.tracker/" + LBBoxFrontURI;
                    break;
                case RelatedMediaSelection.LBBoxArtBack:
                    imageUri = "http://appassets.tracker/" + LBBoxBackURI;
                    break;
                case RelatedMediaSelection.LBBoxArt3D:
                    imageUri = "http://appassets.tracker/" + LBBox3DURI;
                    break;
                case RelatedMediaSelection.LBBoxArtFrontRecon:
                    imageUri = "http://appassets.tracker/" + LBBoxFrontReconURI;
                    break;
                case RelatedMediaSelection.LBBoxArtBackRecon:
                    imageUri = "http://appassets.tracker/" + LBBoxBackReconURI;
                    break;
                case RelatedMediaSelection.LBBoxArtFull:
                    imageUri = "http://appassets.tracker/" + LBBoxFullURI;
                    break;
                case RelatedMediaSelection.LBBoxArtSpine:
                    imageUri = "http://appassets.tracker/" + LBBoxSpineURI;
                    break;
                case RelatedMediaSelection.LBClearLogo:
                    imageUri = "http://appassets.tracker/" + LBClearLogoURI;
                    break;
                case RelatedMediaSelection.LBBanner:
                    imageUri = "http://appassets.tracker/" + LBBannerURI;
                    break;
                case RelatedMediaSelection.LBTitleScreen:
                    imageUri = "http://appassets.tracker/" + LBTitleSceenURI;
                    break;
                case RelatedMediaSelection.LBCartFront:
                    imageUri = "http://appassets.tracker/" + LBCartFrontURI;
                    break;
                case RelatedMediaSelection.LBCartBack:
                    imageUri = "http://appassets.tracker/" + LBCartBackURI;
                    break;
                default:
                    break;
            }

            if (CurrentImageURI == null || !CurrentImageURI.Equals(imageUri))
            {
                RelatedMediaWindow.HideImage();

                if (imageUri.Contains(".png") || imageUri.Contains(".jpg") || imageUri.Contains(".jpeg"))
                {
                    await Task.Delay(500);

                    RelatedMediaWindow.SetImage(imageUri);

                    await Task.Delay(500);

                    RelatedMediaWindow.ShowImage();

                    CurrentImageURI = imageUri;
                }
            }
        }
        public string WindowBackgroundColor
        {
            get
            {
                return Settings.Default.related_media_window_background_color;
            }
            set
            {
                Settings.Default.related_media_window_background_color = value;
                Settings.Default.Save();

                SetAllSettings();
            }
        }
        public RelatedMediaSelection RelatedMediaSelection
        {
            get
            {
                switch (Settings.Default.related_media_selection)
                {
                    case "BADGE_ICON":
                        return RelatedMediaSelection.RABadgeIcon;
                    case "RA_BOX_ART":
                        return RelatedMediaSelection.RABoxArt;
                    case "RA_TITLE_SCREEN":
                        return RelatedMediaSelection.RATitleScreen;
                    case "RA_GAMEPLAY_SCREEN":
                        return RelatedMediaSelection.RAIngameScreen;
                    case "LB_BOX_ART_FRONT":
                        return RelatedMediaSelection.LBBoxArtFront;
                    case "LB_BOX_ART_BACK":
                        return RelatedMediaSelection.LBBoxArtBack;
                    case "LB_BOX_ART_3D":
                        return RelatedMediaSelection.LBBoxArt3D;
                    case "LB_BOX_ART_FRONT_RECON":
                        return RelatedMediaSelection.LBBoxArtFrontRecon;
                    case "LB_BOX_ART_BACK_RECON":
                        return RelatedMediaSelection.LBBoxArtBackRecon;
                    case "LB_BOX_ART_FULL":
                        return RelatedMediaSelection.LBBoxArtFull;
                    case "LB_BOX_ART_SPINE":
                        return RelatedMediaSelection.LBBoxArtSpine;
                    case "LB_CLEAR_LOGO":
                        return RelatedMediaSelection.LBClearLogo;
                    case "LB_BANNER":
                        return RelatedMediaSelection.LBBanner;
                    case "LB_TITLE_SCREEN":
                        return RelatedMediaSelection.LBTitleScreen;
                    case "LB_CART_FRONT":
                        return RelatedMediaSelection.LBCartFront;
                    case "LB_CART_BACK":
                        return RelatedMediaSelection.LBCartBack;
                }
                return RelatedMediaSelection.None;
            }
            set
            {
                if (value != RelatedMediaSelection.None)
                {
                    switch (value)
                    {
                        case RelatedMediaSelection.RABadgeIcon:
                            Settings.Default.related_media_selection = "BADGE_ICON";
                            break;
                        case RelatedMediaSelection.RABoxArt:
                            Settings.Default.related_media_selection = "RA_BOX_ART";
                            break;
                        case RelatedMediaSelection.RATitleScreen:
                            Settings.Default.related_media_selection = "RA_TITLE_SCREEN";
                            break;
                        case RelatedMediaSelection.RAIngameScreen:
                            Settings.Default.related_media_selection = "RA_GAMEPLAY_SCREEN";
                            break;
                        case RelatedMediaSelection.LBBoxArtFront:
                            Settings.Default.related_media_selection = "LB_BOX_ART_FRONT";
                            break;
                        case RelatedMediaSelection.LBBoxArtBack:
                            Settings.Default.related_media_selection = "LB_BOX_ART_BACK";
                            break;
                        case RelatedMediaSelection.LBBoxArt3D:
                            Settings.Default.related_media_selection = "LB_BOX_ART_3D";
                            break;
                        case RelatedMediaSelection.LBBoxArtFrontRecon:
                            Settings.Default.related_media_selection = "LB_BOX_ART_FRONT_RECON";
                            break;
                        case RelatedMediaSelection.LBBoxArtBackRecon:
                            Settings.Default.related_media_selection = "LB_BOX_ART_BACK_RECON";
                            break;
                        case RelatedMediaSelection.LBBoxArtFull:
                            Settings.Default.related_media_selection = "LB_BOX_ART_FULL";
                            break;
                        case RelatedMediaSelection.LBBoxArtSpine:
                            Settings.Default.related_media_selection = "LB_BOX_ART_SPINE";
                            break;
                        case RelatedMediaSelection.LBClearLogo:
                            Settings.Default.related_media_selection = "LB_CLEAR_LOGO";
                            break;
                        case RelatedMediaSelection.LBBanner:
                            Settings.Default.related_media_selection = "LB_BANNER";
                            break;
                        case RelatedMediaSelection.LBTitleScreen:
                            Settings.Default.related_media_selection = "LB_TITLE_SCREEN";
                            break;
                        case RelatedMediaSelection.LBCartFront:
                            Settings.Default.related_media_selection = "LB_CART_FRONT";
                            break;
                        case RelatedMediaSelection.LBCartBack:
                            Settings.Default.related_media_selection = "LB_CART_BACK";
                            break;
                        default:
                            Settings.Default.related_media_selection = "NONE";
                            break;
                    }
                    Settings.Default.Save();
                }
            }
        }
        public string GetRelatedMediaSelectionFolder(RelatedMediaSelection selection)
        {
            switch (selection)
            {
                case RelatedMediaSelection.LBBoxArtFront:
                    return "Box - Front";
                case RelatedMediaSelection.LBBoxArtBack:
                    return "Box - Back";
                case RelatedMediaSelection.LBBoxArt3D:
                    return "Box - 3D";
                case RelatedMediaSelection.LBBoxArtFrontRecon:
                    return "Box - Front - Reconstructed";
                case RelatedMediaSelection.LBBoxArtBackRecon:
                    return "Box - Back - Reconstructed";
                case RelatedMediaSelection.LBBoxArtFull:
                    return "Box - Full";
                case RelatedMediaSelection.LBBoxArtSpine:
                    return "Box - Spine";
                case RelatedMediaSelection.LBClearLogo:
                    return "Clear Logo";
                case RelatedMediaSelection.LBBanner:
                    return "Banner";
                case RelatedMediaSelection.LBTitleScreen:
                    return "Screenshot - Game Title";
                case RelatedMediaSelection.LBCartFront:
                    return "Cart - Front";
                case RelatedMediaSelection.LBCartBack:
                    return "Cart - Back";
                default:
                    return "";
            }
        }
        public string LaunchBoxFilePath
        {
            get
            {
                return Settings.Default.related_media_launchbox_filepath;
            }
            set
            {
                Settings.Default.related_media_launchbox_filepath = value;
                Settings.Default.Save();
            }
        }
        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_related_media;
            }
            set
            {
                Settings.Default.auto_related_media = value;
                Settings.Default.Save();
            }
        }

        public string RABadgeIconURI { get; set; }
        public string RABoxArtURI { get; set; }
        public string RATitleScreenURI { get; set; }
        public string RAScreenshotURI { get; set; }
        public string LBBoxFrontURI { get; set; }
        public string LBBoxBackURI { get; set; }
        public string LBBox3DURI { get; set; }
        public string LBBoxFrontReconURI { get; set; }
        public string LBBoxBackReconURI { get; set; }
        public string LBBoxFullURI { get; set; }
        public string LBBoxSpineURI { get; set; }
        public string LBBannerURI { get; set; }
        public string LBTitleSceenURI { get; set; }
        public string LBClearLogoURI { get; set; }
        public string LBCartFrontURI { get; set; }
        public string LBCartBackURI { get; set; }
    }

    public enum RelatedMediaSelection
    {
        None,
        RABadgeIcon,
        RABoxArt,
        RATitleScreen,
        RAIngameScreen,
        LBBoxArtFront,
        LBBoxArtBack,
        LBBoxArt3D,
        LBBoxArtFrontRecon,
        LBBoxArtBackRecon,
        LBBoxArtFull,
        LBBoxArtSpine,
        LBClearLogo,
        LBBanner,
        LBTitleScreen,
        LBCartFront,
        LBCartBack
    }
}
