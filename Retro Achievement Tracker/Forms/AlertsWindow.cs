using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Retro_Achievement_Tracker.Controllers;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class AlertsWindow : Form
    {
        public AlertsWindow()
        {
            InitializeComponent();
        }
        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            await InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);

            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.images", @"images", CoreWebView2HostResourceAccessKind.DenyCors);
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.video", @"video", CoreWebView2HostResourceAccessKind.DenyCors);

            if (AlertsController.Instance.CustomAchievementEnabled && File.Exists(AlertsController.Instance.CustomAchievementFile))
            {
                webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.customachievement", new FileInfo(AlertsController.Instance.CustomAchievementFile).Directory.FullName, CoreWebView2HostResourceAccessKind.DenyCors);
            }

            if (AlertsController.Instance.CustomMasteryEnabled && File.Exists(AlertsController.Instance.CustomMasteryFile))
            {
                webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.custommastery", new FileInfo(AlertsController.Instance.CustomMasteryFile).Directory.FullName, CoreWebView2HostResourceAccessKind.DenyCors);
            }

            webView21.CoreWebView2.WebMessageReceived += MessageReceived;

            webView21.NavigateToString(Resources.alerts_window);
        }
        public void SetCustomAchievementDirectorMapping()
        {
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.customachievement", new FileInfo(AlertsController.Instance.CustomAchievementFile).Directory.FullName, CoreWebView2HostResourceAccessKind.DenyCors); 
            webView21.NavigateToString(Resources.alerts_window);
        }
        public void SetCustomMasteryDirectorMapping()
        {
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.custommastery", new FileInfo(AlertsController.Instance.CustomMasteryFile).Directory.FullName, CoreWebView2HostResourceAccessKind.DenyCors);
            webView21.NavigateToString(Resources.alerts_window);
        }
        private void MessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            string content = args.TryGetWebMessageAsString();

            if (content.Equals("setIsPlayingTrue"))
            {
                AlertsController.Instance.SetIsPlaying(true);
            }
            else if (content.Equals("setIsPlayingFalse"))
            {
                AlertsController.Instance.SetIsPlaying(false);
            }
            else if (content.StartsWith("setAchievementPlayingTime"))
            {
                AlertsController.Instance.AchievementPlayingTime = float.Parse(content.Replace("setAchievementPlayingTime", ""));
            }
            else if (content.StartsWith("setMasteryPlayingTime"))
            {
                AlertsController.Instance.MasteryPlayingTime = float.Parse(content.Replace("setMasteryPlayingTime", ""));
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            AlertsController.Instance.IsOpen = false;
        }
        public void AssignJavaScriptVariables()
        {
            webView21.ExecuteScriptAsync("assignJavaScriptVariables();");
        }
        public void SetWindowBackgroundColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setWindowBackgroundColor(\"{0}\");", value));
        }
        public void SetBorderBackgroundColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setBorderBackgroundColor(\"{0}\");", value));
        }
        public void SetSimpleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setSimpleFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetSimpleFontColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setSimpleFontColor(\"{0}\");", value));
            SetLineColor(value);
        }
        public void SetSimpleFontOutline(string fontOutline, string borderOutline)
        {
            webView21.ExecuteScriptAsync(string.Format("setSimpleFontOutline(\"{0}\");", fontOutline));
            SetLineOutline(borderOutline);
        }
        public void SetTitleFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setTitleFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetTitleColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setTitleColor(\"{0}\");", value));
        }
        public void SetTitleOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setTitleOutlineColor(\"{0}\");", value));
        }
        public void SetDescriptionFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setDescriptionFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }

        public void SetDescriptionColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setDescriptionColor(\"{0}\");", value));
        }
        public void SetDescriptionOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setDescriptionOutlineColor(\"{0}\");", value));
        }
        public void SetPointsFontFamily(FontFamily value)
        {
            int lineSpacing = value.GetLineSpacing(FontStyle.Regular) / value.GetEmHeight(FontStyle.Regular);

            webView21.ExecuteScriptAsync(string.Format("setPointsFontFamily(\"{0}\", \"{1}\");", value.Name.Replace(":", "\\:"), (lineSpacing == 0 ? 1 : lineSpacing).ToString()));
        }
        public void SetPointsColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setPointsColor(\"{0}\");", value));
        }
        public void SetPointsOutline(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setPointsOutlineColor(\"{0}\");", value));
        }
        public void SetLineColor(string value)
        {
            webView21.ExecuteScriptAsync(string.Format("setLineColor(\"{0}\");", value));
        }
        public void SetLineOutline(string borderOutline)
        {
            webView21.ExecuteScriptAsync(string.Format("setLineOutlineColor(\"{0}\");", borderOutline));
        }
        public void StartAchievementAlert(Achievement achievement)
        {
            webView21.ExecuteScriptAsync($"startAchievementAlert({JsonConvert.SerializeObject(achievement)});");
        }
        public void StartMasteryAlert(GameInfo gameInfo)
        {
            webView21.ExecuteScriptAsync($"startMasteryAlert({JsonConvert.SerializeObject(gameInfo)});");
        }
        public void EnableBorder()
        {
            webView21.ExecuteScriptAsync("enableBorder();");
        }

        public void DisableBorder()
        {
            webView21.ExecuteScriptAsync("disableBorder();");
        }
        public void EnableAchievementEdit()
        {
            webView21.ExecuteScriptAsync("enableAchievementEdit();");

            SetAchievementIn(0, AnimationDirection.STATIC);
        }

        public void DisableAchievementEdit()
        {
            webView21.ExecuteScriptAsync("disableAchievementEdit();");

            SetAchievementOut(0, AnimationDirection.STATIC);
        }

        public void EnableMasteryEdit()
        {
            webView21.ExecuteScriptAsync("enableMasteryEdit();");

            SetMasteryIn(0, AnimationDirection.STATIC);
        }

        public void DisableMasteryEdit()
        {
            webView21.ExecuteScriptAsync("disableMasteryEdit();");

            SetMasteryOut(0, AnimationDirection.STATIC);
        }

        public void SetAchievementLeft(int value)
        {
            webView21.ExecuteScriptAsync(string.Format("setAchievementLeft(\"{0}\");", value + "px"));
        }

        public void SetAchievementTop(int value)
        {
            webView21.ExecuteScriptAsync(string.Format("setAchievementTop(\"{0}\");", value + "px"));
        }

        public void SetMasteryLeft(int value)
        {
            webView21.ExecuteScriptAsync(string.Format("setMasteryLeft(\"{0}\");", value + "px"));
        }

        public void SetMasteryTop(int value)
        {
            webView21.ExecuteScriptAsync(string.Format("setMasteryTop(\"{0}\");", value + "px"));
        }

        public void SetAchievementWidth(int value)
        {
            webView21.ExecuteScriptAsync(string.Format("setAchievementWidth(\"{0}\");", value + "px"));
        }

        public void SetMasteryWidth(int value)
        {
            webView21.ExecuteScriptAsync(string.Format("setMasteryWidth(\"{0}\");", value + "px"));
        }

        public void SetAchievementIn(int value, AnimationDirection animationDirection)
        {
            Invoke(new Action(() =>
            {
                switch (animationDirection)
                {
                    case AnimationDirection.UP:
                        webView21.ExecuteScriptAsync(string.Format("animateAchievementInUp({0});", value.ToString()));
                        break;
                    case AnimationDirection.DOWN:
                        webView21.ExecuteScriptAsync(string.Format("animateAchievementInDown({0});", value.ToString()));
                        break;
                    case AnimationDirection.LEFT:
                        webView21.ExecuteScriptAsync(string.Format("animateAchievementInLeft({0});", value.ToString()));
                        break;
                    case AnimationDirection.RIGHT:
                        webView21.ExecuteScriptAsync(string.Format("animateAchievementInRight({0});", value.ToString()));
                        break;
                    default:
                        webView21.ExecuteScriptAsync("animateAchievementInStatic();");
                        break;
                }
            }));
        }
        public void SetAchievementOut(int value, AnimationDirection animationDirection)
        {
            Invoke(new Action(() =>
            {
                switch (animationDirection)
                {
                    case AnimationDirection.UP:
                        webView21.ExecuteScriptAsync(string.Format("animateAchievementOutUp({0});", value.ToString()));
                        break;
                    case AnimationDirection.DOWN:
                        webView21.ExecuteScriptAsync(string.Format("animateAchievementOutDown({0});", value.ToString()));
                        break;
                    case AnimationDirection.LEFT:
                        webView21.ExecuteScriptAsync(string.Format("animateAchievementOutLeft({0});", value.ToString()));
                        break;
                    case AnimationDirection.RIGHT:
                        webView21.ExecuteScriptAsync(string.Format("animateAchievementOutRight({0});", value.ToString()));
                        break;
                    default:
                        webView21.ExecuteScriptAsync("animateAchievementOutStatic();");
                        break;
                }
            }));
        }
        public void SetMasteryIn(int value, AnimationDirection animationDirection)
        {
            Invoke(new Action(() =>
            {
                switch (animationDirection)
                {
                    case AnimationDirection.UP:
                        webView21.ExecuteScriptAsync(string.Format("animateMasteryInUp({0});", value.ToString()));
                        break;
                    case AnimationDirection.DOWN:
                        webView21.ExecuteScriptAsync(string.Format("animateMasteryInDown({0});", value.ToString()));
                        break;
                    case AnimationDirection.LEFT:
                        webView21.ExecuteScriptAsync(string.Format("animateMasteryInLeft({0});", value.ToString()));
                        break;
                    case AnimationDirection.RIGHT:
                        webView21.ExecuteScriptAsync(string.Format("animateMasteryInRight({0});", value.ToString()));
                        break;
                    default:
                        webView21.ExecuteScriptAsync("animateMasteryInStatic();");
                        break;
                }
            }));
        }
        public void SetMasteryOut(int value, AnimationDirection animationDirection)
        {
            Invoke(new Action(() =>
            {
                switch (animationDirection)
                {
                    case AnimationDirection.UP:
                        webView21.ExecuteScriptAsync(string.Format("animateMasteryOutUp({0});", value.ToString()));
                        break;
                    case AnimationDirection.DOWN:
                        webView21.ExecuteScriptAsync(string.Format("animateMasteryOutDown({0});", value.ToString()));
                        break;
                    case AnimationDirection.LEFT:
                        webView21.ExecuteScriptAsync(string.Format("animateMasteryOutLeft({0});", value.ToString()));
                        break;
                    case AnimationDirection.RIGHT:
                        webView21.ExecuteScriptAsync(string.Format("animateMasteryOutRight({0});", value.ToString()));
                        break;
                    default:
                        webView21.ExecuteScriptAsync("animateMasteryOutStatic();");
                        break;
                }
            }));
        }
        public void HideNotifications()
        {
            webView21.ExecuteScriptAsync("hideNotifications();");
        }
        public void SetAchievementVideo(string filePath)
        {
            webView21.ExecuteScriptAsync(string.Format("setAchievementVideo(\"{0}\");", filePath));
        }
        public void SetMasteryVideo(string filePath)
        {
            webView21.ExecuteScriptAsync(string.Format("setMasteryVideo(\"{0}\");", filePath));
        }
        public void SetClientSize()
        {
            Invoke(new Action(() =>
            {
                ClientSize = new Size(1024, 768);
            }));
        }
        private void NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            AlertsController.Instance.IsOpen = true;
            AlertsController.Instance.SetAllSettings();
        }
    }
}
