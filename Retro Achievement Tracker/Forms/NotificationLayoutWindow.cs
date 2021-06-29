using CefSharp;
using CefSharp.Web;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retro_Achievement_Tracker.Forms
{
    public partial class NotificationLayoutWindow : Form
    {
        private bool isReady = false;

        public Task NotificationsTask;
        public readonly List<NotificationRequest> NotificationRequests;
        public Stopwatch stopwatch;
        public readonly CancellationTokenSource tokenSource2 = new CancellationTokenSource(); 
        
        public NotificationLayoutWindow()
        {
            this.ClientSize = new Size(0, 0);

            FontFamily[] familyArray = FontFamily.Families.ToArray();
            FontFamily[] notificationsFontFamily = familyArray.Where(fontFamily => fontFamily.Name.Equals(Settings.Default.notification_font_family_name)).ToArray();
            FontFamily = notificationsFontFamily[0];

            SetupBrowser();

            if (CustomAchievementEnabled && !File.Exists(this.CustomAchievementFile))
            {
                CustomAchievementEnabled = false;
            }

            if (CustomMasteryEnabled && !File.Exists(this.CustomMasteryFile))
            {
                CustomMasteryEnabled = false;
            }

            this.Name = "RA Tracker - Notifications";
            this.Text = "RA Tracker - Notifications";

            NotificationRequests = new List<NotificationRequest>();

            stopwatch = new Stopwatch();

            RunNotificationTask();

            SetAchievementInAnimation();
            SetAchievementOutAnimation();
        }
        public FontFamily FontFamily
        {
            get
            {
                FontFamily[] familyArray = FontFamily.Families.ToArray();

                foreach (FontFamily font in familyArray)
                {
                    if (font.Name.Equals(Settings.Default.notification_font_family_name))
                    {
                        return font;
                    }
                }
                Settings.Default.notification_font_family_name = familyArray[0].Name;
                Settings.Default.Save();

                return familyArray[0];
            }
            set
            {
                Settings.Default.notification_font_family_name = value.Name;
                Settings.Default.Save();

                SetFontFamily();
            }
        }
        public string FontColor
        {
            get
            {
                return Settings.Default.notification_font_color_hex_code;
            }
            set
            {
                Settings.Default.notification_font_color_hex_code = value;
                Settings.Default.Save();

                SetFontColor();
            }
        }
        public string FontOutlineColor
        {
            get
            {
                return Settings.Default.notification_font_outline_color_hex;
            }
            set
            {
                Settings.Default.notification_font_outline_color_hex = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public int FontOutlineSize
        {
            get
            {
                return Settings.Default.notification_font_outline_size;
            }
            set
            {
                Settings.Default.notification_font_outline_size = value;
                Settings.Default.Save();

                SetFontOutline();
            }
        }
        public bool FontOutlineEnable
        {
            get
            {
                return Settings.Default.notification_font_outline_enabled;
            }
            set
            {
                Settings.Default.notification_font_outline_enabled = value;
                Settings.Default.Save();

                SetFontOutline();
            }

        }
        public bool PointsEnable
        {
            get
            {
                return Settings.Default.notifications_points_enable;
            }
            set
            {
                Settings.Default.notifications_points_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    ShowPoints();
                }
                else
                {
                    HidePoints();
                }
            }
        }
        public bool BorderEnable
        {
            get
            {
                return Settings.Default.notifications_border_enable;
            }
            set
            {
                Settings.Default.notifications_border_enable = value;
                Settings.Default.Save();

                if (value)
                {
                    EnableBorder();
                }
                else
                {
                    DisableBorder();
                }
            }
        }
        public bool CustomAchievementEnabled
        {
            set
            {
                Settings.Default.notification_custom_achievement_enable = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_enable;
            }
        }
        public bool CustomMasteryEnabled
        {
            set
            {
                Settings.Default.notification_custom_mastery_enable = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_enable;
            }
        }
        public int CustomAchievementX
        {
            set
            {
                Settings.Default.notification_custom_achievement_x = value;
                Settings.Default.Save();

                SetAchievementLeft();
            }

            get
            {
                return Settings.Default.notification_custom_achievement_x;
            }
        }
        public int CustomAchievementY
        {
            set
            {
                Settings.Default.notification_custom_achievement_y = value;
                Settings.Default.Save();

                SetAchievementTop();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_y;
            }
        }
        public int CustomMasteryX
        {
            set
            {
                Settings.Default.notification_custom_mastery_x = value;
                Settings.Default.Save();

                SetMasteryLeft();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_x;
            }
        }
        public int CustomMasteryY
        {
            set
            {
                Settings.Default.notification_custom_mastery_y = value;
                Settings.Default.Save();

                SetMasteryTop();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_y;
            }
        }
        public decimal CustomAchievementScale
        {
            set
            {
                Settings.Default.notification_custom_achievement_scale = value;
                Settings.Default.Save();

                SetAchievementWidth();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_scale;
            }
        }
        public decimal CustomMasteryScale
        {
            set
            {
                Settings.Default.notification_custom_mastery_scale = value;
                Settings.Default.Save();

                SetMasteryWidth();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_scale;
            }
        }
        public int CustomAchievementIn
        {
            get
            {
                return Settings.Default.notification_custom_achievement_fade_in;
            }
            set
            {
                Settings.Default.notification_custom_achievement_fade_in = value;
                Settings.Default.Save();
            }
        }
        public int CustomAchievementOut
        {
            get
            {
                return Settings.Default.notification_custom_achievement_fade_out;
            }
            set
            {
                Settings.Default.notification_custom_achievement_fade_out = value;
                Settings.Default.Save();
            }
        }
        public int CustomMasteryIn
        {
            get
            {
                return Settings.Default.notification_custom_mastery_fade_in;
            }
            set
            {
                Settings.Default.notification_custom_mastery_fade_in = value;
                Settings.Default.Save();
            }
        }
        public int CustomMasteryOut
        {
            get
            {
                return Settings.Default.notification_custom_mastery_fade_out;
            }
            set
            {
                Settings.Default.notification_custom_mastery_fade_out = value;
                Settings.Default.Save();
            }
        }
        public AnimationDirection AchievementAnimationIn
        {
            get
            {
                switch (Settings.Default.notifications_achievement_in_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                Settings.Default.notifications_achievement_in_animation = value.ToString();
                Settings.Default.Save();

                SetAchievementInAnimation();

            }
        }
        public AnimationDirection AchievementAnimationOut
        {
            get
            {
                switch (Settings.Default.notifications_achievement_out_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                Settings.Default.notifications_achievement_out_animation = value.ToString();
                Settings.Default.Save();

                SetAchievementOutAnimation();
            }
        }
        public AnimationDirection MasteryAnimationIn
        {
            get
            {
                switch (Settings.Default.notifications_mastery_in_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                Settings.Default.notifications_mastery_in_animation = value.ToString();
                Settings.Default.Save();

                SetMasteryInAnimation();
            }
        }
        public AnimationDirection MasteryAnimationOut
        {
            get
            {
                switch (Settings.Default.notifications_mastery_out_animation)
                {
                    case "DOWN":
                        return AnimationDirection.DOWN;
                    case "LEFT":
                        return AnimationDirection.LEFT;
                    case "RIGHT":
                        return AnimationDirection.RIGHT;
                    case "UP":
                        return AnimationDirection.UP;
                }
                return AnimationDirection.STATIC;
            }
            set
            {
                Settings.Default.notifications_mastery_out_animation = value.ToString();
                Settings.Default.Save();

                SetMasteryOutAnimation();
            }
        }
        public string CustomAchievementFile
        {
            set
            {
                Settings.Default.notification_custom_achievement_file = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_achievement_file;
            }
        }
        public string CustomMasteryFile
        {
            set
            {
                Settings.Default.notification_custom_mastery_file = value;
                Settings.Default.Save();
            }
            get
            {
                return Settings.Default.notification_custom_mastery_file;
            }
        }
        public string BackgroundColor
        {
            get
            {
                return Settings.Default.notifications_background_color;
            }
            set
            {
                Settings.Default.notifications_background_color = value;
                Settings.Default.Save();

                SetBackgroundColor();
            }
        }
        public bool AutoLaunch
        {
            get
            {
                return Settings.Default.auto_notifications;
            }
            set
            {
                Settings.Default.auto_notifications = value;
                Settings.Default.Save();
            }
        }
        
        public void FireNotifications()
        {
            if (NotificationRequests.Count > 0 && !stopwatch.IsRunning && NotificationsTask.Status != TaskStatus.Running)
            {
                RunNotificationTask();
            }
        }

        public void RunNotificationTask()
        {
            NotificationsTask = Task.Factory.StartNew(async () =>
            {
                long delayInMilli = 0;

                while (NotificationRequests.Count > 0 || stopwatch.IsRunning)
                {
                    if (tokenSource2.Token.IsCancellationRequested)
                    {
                        tokenSource2.Token.ThrowIfCancellationRequested();
                    }

                    if (!stopwatch.IsRunning)
                    {
                        if (!this.IsDisposed)
                        {
                            if (NotificationRequests.Count > 0)
                            {
                                NotificationRequest notificationRequest = NotificationRequestDequeue();

                                if (tokenSource2.Token.IsCancellationRequested)
                                {
                                    tokenSource2.Token.ThrowIfCancellationRequested();
                                }

                                if (notificationRequest != null)
                                {
                                    if (notificationRequest.Achievement != null)
                                    {
                                        SendAchievementNotification(notificationRequest.Achievement);

                                        stopwatch = Stopwatch.StartNew();

                                        SetAchievementIn();
                                        SetAchievementOut();

                                        delayInMilli = CustomAchievementEnabled ? MediaHelper.GetVideoDuration(CustomAchievementFile) : 7000;
                                    }
                                    else if (notificationRequest.GameSummary != null && notificationRequest.GameAchievementSummary != null)
                                    {
                                        SendMasteryNotification(notificationRequest.GameSummary, notificationRequest.GameAchievementSummary);

                                        stopwatch = Stopwatch.StartNew();

                                        SetMasteryIn();
                                        SetMasteryOut();

                                        delayInMilli = CustomMasteryEnabled ? MediaHelper.GetVideoDuration(CustomMasteryFile) : 11000;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (stopwatch.ElapsedMilliseconds > delayInMilli)
                        {
                            HideNotifications();

                            stopwatch.Stop();

                            delayInMilli = 0;
                        }
                        else
                        {
                            await Task.Delay(100);
                        }
                    }
                }
            }, tokenSource2.Token);
        }
        private NotificationRequest NotificationRequestDequeue()
        {
            NotificationRequest notificationRequest = NotificationRequests[0];

            NotificationRequests.Remove(notificationRequest);

            return notificationRequest;
        }

        public void EnqueueAchievementNotification(Achievement achievement)
        {
            if (CustomAchievementEnabled && string.IsNullOrEmpty(CustomAchievementFile))
            {
                CustomAchievementEnabled = false;
            }
            if (CustomMasteryEnabled && string.IsNullOrEmpty(CustomMasteryFile))
            {
                CustomMasteryEnabled = false;
            }

            NotificationRequest notificationRequest = new NotificationRequest
            {
                Achievement = achievement
            };

            NotificationRequests.Add(notificationRequest);
        }

        public void EnqueueMasteryNotification(GameSummary gameSummary, GameAchievementSummary gameAchievementSummary)
        {
            NotificationRequest notificationRequest = new NotificationRequest
            {
                GameSummary = gameSummary,
                GameAchievementSummary = gameAchievementSummary
            };
            NotificationRequests.Add(notificationRequest);
        }

        public async void SendAchievementNotification(Achievement achievement)
        {
            await ExecuteScript("achievementNotification(\"" + achievement.Title.Replace("\"", "\\\"") + "\"," +
                                       "\"https://retroachievements.org/Badge/" + achievement.BadgeNumber + ".png\",\"" +
                                       achievement.Description.Replace("\"", "\\\"") + "\",\"" + achievement.Points + "\");");
        }

        public async void SendMasteryNotification(GameSummary gameSummary, GameAchievementSummary gameAchievementSummary)
        {
            await ExecuteScript("masteryNotification(\"" + gameSummary.Title.Replace("\"", "\\\"") + "\"," +
                                                "\"https://retroachievements.org" + gameSummary.ImageIcon + "\"," +
                                                "\"" + gameAchievementSummary.NumPossibleAchievements + "\"," +
                                                "\"" + gameAchievementSummary.PossibleScore + "\");");
        }
        private async void PromptUserInput()
        {
            await ExecuteScript("promptUser();");
        }
        private async void EnableBorder()
        {
            await ExecuteScript("enableBorder();");
        }
        private async void DisableBorder()
        {
            await ExecuteScript("disableBorder();");
        }
        private async void ShowPoints()
        {
            await ExecuteScript("showPoints();");
        }
        private async void HidePoints()
        {
            await ExecuteScript("hidePoints();");
        }
        public async void EnableAchievementEdit()
        {
            await ExecuteScript("enableEditModeAchievement();");
        }
        public async void DisableAchievementEdit()
        {
            await ExecuteScript("disableEditModeAchievement();");
        }
        public async void EnableMasteryEdit()
        {
            await ExecuteScript("enableEditModeMastery();");
        }
        public async void DisableMasteryEdit()
        {
            await ExecuteScript("disableEditModeMastery();");
        }
        public async void SetAchievementLeft()
        {
            await ExecuteScript("setAchievementLeft(\"" + (CustomAchievementEnabled ? CustomAchievementX : -25) + "px\");");
        }
        public async void SetAchievementTop()
        {
            await ExecuteScript("setAchievementTop(\"" + (CustomAchievementEnabled ? CustomAchievementY : 5) + "px\");");
        }
        public async void SetMasteryLeft()
        {
            await ExecuteScript("setMasteryLeft(\"" + (CustomMasteryEnabled ? CustomMasteryX : -25) + "px\");");
        }
        public async void SetMasteryTop()
        {
            await ExecuteScript("setMasteryTop(\"" + (CustomMasteryEnabled ? CustomMasteryY : 5) + "px\");");
        }
        public async void SetAchievementWidth()
        {
            await ExecuteScript("setAchievementWidth(\"" + (CustomAchievementEnabled ? Convert.ToInt32(CustomAchievementScale * MediaHelper.GetVideoWidth(CustomAchievementFile)) : 1028) + "px\");");
        }
        public async void SetMasteryWidth()
        {
            await ExecuteScript("setMasteryWidth(\"" + (CustomMasteryEnabled ? Convert.ToInt32(CustomMasteryScale * MediaHelper.GetVideoWidth(CustomMasteryFile)) : 1028) + "px\");");
        }

        public async void SetAchievementIn()
        {
            await ExecuteScript("setAchievementIn(" + (CustomAchievementEnabled ? CustomAchievementIn : 0) + ");");
        }

        public async void SetAchievementOut()
        {
            await ExecuteScript("setAchievementOut(" + (CustomAchievementEnabled ? CustomAchievementOut : 5550) + ");");
        }
        public async void SetMasteryIn()
        {
            await ExecuteScript("setMasteryIn(" + (CustomMasteryEnabled ? CustomMasteryIn : 0) + ");");
        }
        public async void SetMasteryOut()
        {
            await ExecuteScript("setMasteryOut(" + (CustomMasteryEnabled ? CustomMasteryOut : 5550) + ");");
        }
        public async void SetAchievementInAnimation()
        {
            await ExecuteScript("setAnimationAchievementIn(\"" + (CustomAchievementEnabled ? AchievementAnimationIn.ToString() : AnimationDirection.STATIC.ToString()) + "\");");
        }
        public async void SetAchievementOutAnimation()
        {
            await ExecuteScript("setAnimationAchievementOut(\"" + (CustomAchievementEnabled ? AchievementAnimationOut.ToString() : AnimationDirection.UP.ToString()) + "\");");
        }
        public async void SetMasteryInAnimation()
        {
            await ExecuteScript("setAnimationMasteryIn(\"" + (CustomMasteryEnabled ? MasteryAnimationIn.ToString() : AnimationDirection.STATIC.ToString()) + "\");");
        }
        public async void SetMasteryOutAnimation()
        {
            await ExecuteScript("setAnimationMasteryOut(\"" + (CustomMasteryEnabled ? MasteryAnimationOut.ToString() : AnimationDirection.UP.ToString()) + "\");");
        }
        private async void HideNotifications()
        {
            await ExecuteScript("hideNotifications();");
        }
        private async void SetFontColor()
        {
            await ExecuteScript("setFontColor(\"" + FontColor + "\");");
        }

        public async void SetFontFamily()
        {

            await ExecuteScript(string.Format("setFont(\"{0}\", \"{1}\");", FontFamily.Name.Replace(":", "\\\\:"), FontFamily.GetLineSpacing(FontStyle.Regular) / FontFamily.GetEmHeight(FontStyle.Regular)));
        }

        private async void SetFontOutline()
        {
            if (FontOutlineEnable)
            {
                await ExecuteScript("setFontOutline(\"" + FontOutlineColor + " " + FontOutlineSize + "px\");");
                await ExecuteScript("setBorderOutline(\"" + FontOutlineSize + "px solid " + FontOutlineColor + "\");");
            }
            else
            {
                await ExecuteScript("setFontOutline(\"0px\");");
                await ExecuteScript("setBorderOutline(\"0px\");");
            }
        }
        private async void SetBackgroundColor()
        {
            await ExecuteScript("setBackgroundColor(\"" + BackgroundColor + "\");");
        }
        protected async Task ExecuteScript(string script)
        {
            if (this.Visible && this.isReady)
            {
                try
                {
                    await chromiumWebBrowser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(5));
                }
                catch (Exception)
                {
                }
            }
        }

        public void SetupBrowser()
        {
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser(new HtmlString(Resources.NotificationWindow))
            {
                ActivateBrowserOnCreation = false,
                Location = new Point(0, 0),
                Name = "chromiumWebBrowser",
                Size = new Size(1920, 1080),
                TabIndex = 0,
                Dock = DockStyle.None,
                RequestHandler = new CustomRequestHandler()
            };

            chromiumWebBrowser.RequestHandler = new CustomRequestHandler()
            {
                customAchievementEnabled = CustomAchievementEnabled,
                customMasteryEnabled = CustomMasteryEnabled
            };
            chromiumWebBrowser.FrameLoadEnd += new EventHandler<FrameLoadEndEventArgs>((sender, frameLoadEndEventArgs) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    this.ClientSize = new Size(1024, 768);
                    this.isReady = true;
                });

                SetFontFamily();
                SetFontColor();
                SetFontOutline();

                PromptUserInput();

                SetAchievementWidth();
                SetMasteryWidth();

                SetAchievementTop();
                SetMasteryTop();

                SetAchievementLeft();
                SetMasteryLeft();

                SetAchievementInAnimation();
                SetAchievementOutAnimation();

                SetMasteryInAnimation();
                SetMasteryOutAnimation();
                SetBackgroundColor();

                if (BorderEnable)
                {
                    EnableBorder();
                }
                else
                {
                    DisableBorder();
                }
                if (PointsEnable)
                {
                    ShowPoints();
                }
                else
                {
                    HidePoints();
                }
            });
            chromiumWebBrowser.LoadHtml(Resources.NotificationWindow);

            this.Controls.Add(this.chromiumWebBrowser);
        }

        public CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;

        public class NotificationRequest
        {
            public Achievement Achievement { get; set; }
            public GameSummary GameSummary { get; set; }
            public GameAchievementSummary GameAchievementSummary { get; set; }
        }

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationLayoutWindow));
            this.SuspendLayout();
            // 
            // NotificationLayoutWindow
            // 
            this.ClientSize = new Size(284, 261);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotificationLayoutWindow";
            this.ResumeLayout(false);
        }
    }
}
